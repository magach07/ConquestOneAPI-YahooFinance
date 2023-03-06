using ConquestOne.Application.DTO;
using ConquestOne.Application.Interfaces;
using ConquestOne.Application.Receivers.Interfaces;
using ConquestOne.Domain.Entities;

namespace ConquestOne.Application.Receivers
{
    public class InsertReceiver : IReceiver<List<PETR4Entity>, State>
    {
        private readonly IFinanceRepository _financeRepository;

        public InsertReceiver(IFinanceRepository financeRepository)
        {
            _financeRepository = financeRepository;        
        }

        public State Action (List<PETR4Entity> dto)
        {
            try
            {
                foreach (var iten in dto)
                {
                    var petr4 = new PETR4Entity(iten.Date, iten.Value, iten.VariationPreviousDate, iten.VariationFirstDate);
                    _financeRepository.InsertPETR4(iten);
                }
                
                return new State(200, "Informacoes adicionadas com sucesso", dto);
            }
            catch (Exception e)
            {
                return new State(500, e.Message, null);
            }

            return new State(400, "Erro ao inserir, verifique os dados novamente", null);
        }

    
    }
}   