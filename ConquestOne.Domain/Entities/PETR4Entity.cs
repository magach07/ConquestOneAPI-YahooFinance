namespace ConquestOne.Domain.Entities
{
    public class PETR4Entity
    {
        public PETR4Entity(DateTime date, double value, double variationPreviousDate, double variationFirstDate)
        {
            Date = date;
            Value = value;
            VariationPreviousDate = variationPreviousDate;
            VariationFirstDate = variationFirstDate;
        }

        public PETR4Entity()
        {
            
        }

        public DateTime Date { get; set; }
        public double Value { get; set; }
        public double VariationPreviousDate { get; set; }
        public double VariationFirstDate { get; set; }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}