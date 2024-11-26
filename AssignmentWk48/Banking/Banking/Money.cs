namespace Banking
{
    public class Money
    {
        public decimal Amount { get; set; }
        public Currency Currency { get; private set; }

        public string ToString()
        {
            return Amount + " " + Currency;
        }
        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public void ChangeCurrency(Currency currency, CurrencyConverter converter)
        {
            // IF we have the correct currency already, do nothing.
            if (this.Currency == currency) return;
            // If the Money is Euro we can either exchange it to SEK, or Dollar
            else if (this.Currency == Currency.Euro)
            {
                if (currency == Currency.SEK)
                {
                    this.Amount = converter.ConvertEuroToSek(this.Amount);
                }
                else
                {
                    this.Amount = converter.ConvertEuroToDollar(this.Amount);
                }
            }
            // IF the money is Dollar we can either exchange it to SEK or Euro
            else if (this.Currency == Currency.Dollar)
            {
                if (currency == Currency.SEK)
                {
                    this.Amount = converter.ConvertDollarToSek(this.Amount);
                }
                else
                {
                    this.Amount = converter.ConvertDollarToEuro(this.Amount);
                }
            }
            // IF the money is SEK we can either exchange it for Euro or Dollar
            else if (this.Currency == Currency.SEK)
            {
                if (currency == Currency.Euro)
                {
                    this.Amount = converter.ConvertSekToEuro(this.Amount);
                }
                else
                {
                    this.Amount = converter.ConvertSekToDollar(this.Amount);
                }
             
            }
            // After changing the amount also change the Currency
            this.Currency = currency;
            return;
        }

        /* Methods within Money to convert.. INCORRECT Interpretation of Instructions
        public bool ConvertDollarToSek(CurrencyConverter currencyConverter)
        {
            if (Amount != 0 && Currency == Currency.Dollar)
            {
                Amount = Amount * (currencyConverter.SEK / currencyConverter.Dollar);
                Currency = Currency.SEK;
                return true;
            }
            return false;
        }
        public bool ConvertDollarToEuro(CurrencyConverter currencyConverter)
        {
            if (Amount != 0 && Currency == Currency.Dollar)
            {
                Amount = Amount * ( currencyConverter.Euro / currencyConverter.Dollar);
                Currency = Currency.Euro;
                return true;
            }
                return false;
        }
        public bool ConvertEuroToDollar(CurrencyConverter currencyConverter)
        {
            if (this.Amount != 0 && Currency == Currency.Euro)
            {
                this.Amount = Amount * (currencyConverter.Dollar / currencyConverter.Euro);
                Currency = Currency.Dollar;
                return true;
            }
            return false;
        }
        public bool ConvertEuroToSek(CurrencyConverter currencyConverter)
        {
            if (this.Amount != 0 && Currency == Currency.Euro)
            {
                this.Amount = Amount * (currencyConverter.SEK / currencyConverter.Euro);
                return true;
                Currency = Currency.SEK;
            }
            return false;
        }
        public bool ConvertSekToDollar(CurrencyConverter currencyConverter)
        {
            if (this.Amount != 0 && Currency == Currency.SEK)
            {
                this.Amount = Amount * (currencyConverter.Dollar / currencyConverter.SEK);
                Currency = Currency.Dollar;
                return true;
            }
            return false;
        }
        public bool ConvertSekToEuro(CurrencyConverter currencyConverter)
        {
            if (this.Amount != 0 && Currency == Currency.SEK)
            {
                this.Amount = Amount * (currencyConverter.Euro / currencyConverter.SEK);
                Currency = Currency.Euro;
                return true;
            }
            return false;
        }
        */
    }
}
