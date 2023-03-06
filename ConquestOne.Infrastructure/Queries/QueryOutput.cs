using ConquestOne.Infrastructure.Mapping;

namespace ConquestOne.Infrastructure.Queries
{
    public class QueryOutput : BaseQuery
    {
        public QueryModel GetHistoric30Days()
        {
            this.Table = Map.GetYahooFinanceTable();
            this.Query = $@"
                SELECT 
                PET.[ID] AS [Dia],
                CONVERT(VARCHAR(10), PET.[CL_DATE], 103) AS [DATE],
                CONCAT('R$', PET.[CL_VALUE]) AS [Value],
                CONCAT(PET.[CL_VARIATION_PREVIOUS_DATE], '%') AS [VariationPreviousDate],
                CONCAT(PET.[CL_VARIATION_FIRST_DATE], '%') AS [VariationFirstDate]
                FROM {this.Table} AS PET
            ";

            return new QueryModel(this.Query, null);
        }
    }
}