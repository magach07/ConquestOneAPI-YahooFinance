using System.Data.SqlTypes;
using ConquestOne.Application.Commands.Interfaces;

namespace ConquestOne.Application.DTO
{
    public class PETR4AnalyticsDTO
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public double VariationPreviousDate { get; set; }
        public double VariationFirstDate { get; set; }
    }
}