using System.Net.Http;
using System.Threading.Tasks;
using ConquestOne.Application.DTO;
using ConquestOne.Application.Interfaces;
using Newtonsoft.Json;

namespace ConquestOne.Infrastructure.Services
{
    public class FinanceService : IFinanceService
    {
        public async Task<string> GetAllPETR4()
        {
            string yahooFinance = "https://query2.finance.yahoo.com/v8/finance/chart/PETR4.SA?symbol=PETR4.SA&period1=1675422000&period2=9999999999&interval=1d";

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(yahooFinance);

            var data = await response.Content.ReadAsStringAsync();

            var json = JsonConvert.DeserializeObject<PETR4DTO>(data);

            return data;
        }
    }
}