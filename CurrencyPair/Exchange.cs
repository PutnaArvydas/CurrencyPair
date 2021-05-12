using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyPair
{
    public class Exchange
    {
        private List<Currency> CurrencyList;
        public Exchange()
        {
            CurrencyList = new List<Currency>();
            CurrencyList.Add(new Currency("EUR", 743.94m));
            CurrencyList.Add(new Currency("USD", 663.11m));
            CurrencyList.Add(new Currency("GBP", 852.85m));
            CurrencyList.Add(new Currency("SEK", 76.104m));
            CurrencyList.Add(new Currency("NOK", 78.40m));
            CurrencyList.Add(new Currency("CHF", 683.58m));
            CurrencyList.Add(new Currency("JPY", 597.40m));
            CurrencyList.Add(new Currency("DKK", 100m));
        }

        public decimal CalculateAmount(ParsedData parsedData)
        {
            CheckIfCurencyValid(parsedData.CurencyFrom);
            CheckIfCurencyValid(parsedData.CurencyTo);
            if (parsedData.CurencyFrom == parsedData.CurencyTo)
            {
                return parsedData.AmountFrom;
            }

            return CalculateAmountTo(parsedData);
        }

        private void CheckIfCurencyValid(string curencyCode)
        {
            if(null == FindCurrency(curencyCode))
            {
                throw new Exception($"Courency code \"{curencyCode}\" not defined!");
            }
        }

        private Currency FindCurrency (string currencyCode)
        {
            if (null == currencyCode) throw new Exception("Currency not defined!");
            return CurrencyList.Where(x => x.CurrencyISO.ToUpper() == currencyCode.ToUpper())
                .Select(x => x)
                .FirstOrDefault();
        }

        private decimal CalculateAmountTo(ParsedData parsedData)
        {
            Currency curencyFrom = FindCurrency(parsedData.CurencyFrom);
            Currency curencyTo = FindCurrency(parsedData.CurencyTo);
            return Math.Round(curencyFrom.Amount * parsedData.AmountFrom / curencyTo.Amount, 4);
        }

    }
}
