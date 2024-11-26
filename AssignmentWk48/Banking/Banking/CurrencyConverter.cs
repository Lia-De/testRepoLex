namespace Banking
{
    public class CurrencyConverter
    {
        public decimal Dollar{ get; private set; }
        public decimal Euro { get; private set; }
        public decimal SEK { get; private set; }

        public CurrencyConverter(decimal dollarValue, decimal euroValue, decimal sekValue) 
        {
            Dollar = dollarValue;
            Euro = euroValue;
            SEK = sekValue;
        }

        public decimal ConvertDollarToEuro(decimal amount)
        {
            return (Euro / Dollar) * amount;
        }
        public decimal ConvertDollarToSek(decimal amount)
        {
            return (SEK / Dollar) * amount;
        }
        public decimal ConvertSekToEuro(decimal amount)
        {
            return (Euro / SEK) * amount;
        }
        public decimal ConvertSekToDollar(decimal amount)
        {
            return (Dollar/ SEK) * amount;
        }

        public decimal ConvertEuroToDollar(decimal amount)
        {
            return (Dollar / Euro) * amount;
        }
        public decimal ConvertEuroToSek(decimal amount)
        {
            return (SEK / Euro) * amount;
        }

    }
}
