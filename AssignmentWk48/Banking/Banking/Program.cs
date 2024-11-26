using Banking;
Money newMoney = new Money(500, Currency.Dollar);

CurrencyConverter novemberConverter = new CurrencyConverter(0.095m, 0.085m, 1m);

Console.WriteLine(newMoney.ToString());

newMoney.ChangeCurrency(Currency.SEK, novemberConverter);

Console.WriteLine(newMoney.ToString());

newMoney.ChangeCurrency(Currency.SEK, novemberConverter);

Console.WriteLine("Should not change: \n"+newMoney.ToString());

newMoney.ChangeCurrency(Currency.Euro, novemberConverter);

Console.WriteLine(newMoney.ToString());

newMoney.ChangeCurrency(Currency.SEK, novemberConverter);

Console.WriteLine(newMoney.ToString());

newMoney.ChangeCurrency(Currency.Dollar, novemberConverter);

Console.WriteLine(newMoney.ToString());


/* Methods where Money does the conversion 
         newMoney.ConvertDollarToSek(novemberConverter);

        Console.WriteLine(newMoney.ToString());

        newMoney.ConvertDollarToSek(novemberConverter);

        Console.WriteLine(" Should not change, wrong currency: " + newMoney.ToString());

        newMoney.Amount = 100;
        Console.WriteLine("Changing amount: " + newMoney.ToString());

        newMoney.ConvertSekToEuro(novemberConverter);

        Console.WriteLine(newMoney.ToString());

        newMoney.ConvertEuroToDollar(novemberConverter);

        Console.WriteLine(newMoney.ToString());

        newMoney.ConvertEuroToSek(novemberConverter);

        Console.WriteLine(" Should not change, wrong currency: " + newMoney.ToString());

        newMoney.ConvertDollarToSek(novemberConverter);

        Console.WriteLine(newMoney.ToString());
*/

