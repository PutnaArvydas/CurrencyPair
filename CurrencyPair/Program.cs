using System;

namespace CurrencyPair
{
    class Program
    {
        static void Main(string[] args)
        {
            Exchange exchange = new Exchange();
            bool doNextIteration = true;
            Console.WriteLine("Usage: Exchange <currency code>/<currency code> <amount to exchange>");
            while(doNextIteration)
            {
                try
                {
                    ParsedData curencyPair = Utility.Console.TakeCurrencyPair();
                    curencyPair.AmountTo = exchange.CalculateAmount(curencyPair);
                    Utility.Console.DisplayResults(curencyPair);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
                doNextIteration = Utility.Console.NextAction();
            }
        }
    }
}
