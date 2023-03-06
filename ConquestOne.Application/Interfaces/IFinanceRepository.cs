using ConquestOne.Application.DTO;
using ConquestOne.Domain.Entities;

namespace ConquestOne.Application.Interfaces
{
    public interface IFinanceRepository
    {
        Task<List<PETR4AnalyticsDTO>> GetAll();
        void InsertPETR4(PETR4Entity dto);
        IEnumerable<PETR4ReturnDTO> GetHistoric30Days();
    }
}