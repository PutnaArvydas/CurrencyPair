namespace CurrencyPair
{
    class Currency
    {
        public string CurrencyISO { get; set; }
        public decimal Amount { get; set; }

        public Currency(string currencyISO, decimal amount)
        {
            CurrencyISO = currencyISO;
            Amount = amount;
        }
    }
}
