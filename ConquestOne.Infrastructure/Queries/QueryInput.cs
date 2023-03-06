using ConquestOne.Domain.Entities;
using ConquestOne.Infrastructure.Mapping;

namespace ConquestOne.Infrastructure.Queries
{
    public class QueryInput : BaseQuery
    {
        public QueryModel InsertPETR4Query(PETR4Entity dto)
        {
            this.Table = Map.GetYahooFinanceTable();
            this.Query = $@"
                INSERT INTO {this.Table}
                VALUES
                (
                    @Date,
                    @Value,
                    @Variation_Previous_Date,
                    @Variation_First_Date
                )
            ";

            this.Parameters = new
            {
                Date = dto.Date,
                Value = dto.Value,
                Variation_Previous_Date = dto.VariationPreviousDate,
                Variation_First_Date = dto.VariationFirstDate
            };

            return new QueryModel(this.Query, this.Parameters);
        }
    }
}