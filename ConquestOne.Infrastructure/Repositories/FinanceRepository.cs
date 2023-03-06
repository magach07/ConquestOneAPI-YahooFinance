using System.Data;
using ConquestOne.Application.DTO;
using ConquestOne.Application.Interfaces;
using ConquestOne.Domain.Entities;
using ConquestOne.Infrastructure.Factory;
using ConquestOne.Infrastructure.Queries;
using Dapper;
using Newtonsoft.Json;

namespace ConquestOne.Infrastructure.Repositories
{
    public class FinanceRepository : IFinanceRepository
    {
        private readonly IFinanceService _financeService;
        private readonly IDbConnection _connection;

        public FinanceRepository(IFinanceService financeService, SqlFactory factory)
        {
            _financeService = financeService;
            _connection = factory.SqlConnection();
        }

        public async Task<List<PETR4AnalyticsDTO>> GetAll()
        {
            var jsonCompleto = _financeService.GetAllPETR4();
            
            var json = JsonConvert.DeserializeObject<PETR4DTO>(await jsonCompleto);

            List<PETR4AnalyticsDTO> analyticsDTO = new List<PETR4AnalyticsDTO>();
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);


            var timestamp = json.Chart.Result[0].Timestamp[0];

            for (int i = 0; i < json.Chart.Result[0].Timestamp.Count; i++)
            {
                var valueFirstDate = json.Chart.Result[0].Indicators.Quote[0].Open[0];
                var valueToday = json.Chart.Result[0].Indicators.Quote[0].Open[i];

                PETR4AnalyticsDTO dto = new PETR4AnalyticsDTO();
            
                var date = dateTime.AddSeconds(json.Chart.Result[0].Timestamp[i]).ToLocalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
                dto.Date = Convert.ToDateTime(date);
                dto.Value = Math.Round(valueToday, 2);
                if (i > 0)
                {
                    var valuePreviousDate = json.Chart.Result[0].Indicators.Quote[0].Open[i - 1];
                    dto.VariationPreviousDate = Math.Round(((valueToday / valuePreviousDate) - 1) * 100, 2);
                    dto.VariationFirstDate = Math.Round(((valueToday / valueFirstDate) - 1) * 100, 2);
                }
                else
                {
                    dto.VariationPreviousDate = 0;
                    dto.VariationFirstDate = 0;
                }
                
                analyticsDTO.Add(dto);
            }

            return analyticsDTO;
        }

        public void InsertPETR4(PETR4Entity dto)
        {
            _connection.Open();

            try
            {
                var query = new QueryInput().InsertPETR4Query(dto);
                _connection.Execute(query.Query, query.Parameters);
            }
            catch
            {
                throw new Exception("Erro ao inserir dados.");
            }

            _connection.Close();
        }

        public IEnumerable<PETR4ReturnDTO> GetHistoric30Days ()
        {
            var query = new QueryOutput().GetHistoric30Days();

            try
            {
                return _connection.Query<PETR4ReturnDTO>(query.Query) as List<PETR4ReturnDTO>;
            }
            catch
            {
                throw new Exception("Falha ao recuperar historico.");
            }
        }
    }
}