using System;
using System.Linq;
using CurrencyPair;
using System.Text.RegularExpressions;

namespace Utility
{
    public class Console
    {
        public static ParsedData TakeCurrencyPair()
        {
            System.Console.Write("Exchange: ");
            string curencyPairString = System.Console.ReadLine();
            ParsedData parsedData = ParseData(curencyPairString);
            return parsedData;
        }

        public static bool NextAction()
        {
            System.Console.WriteLine("Do you want exit? y/n");
            string decision = System.Console.ReadLine();
            if(decision != "y")
            {
                return false;
            }
            return true;
        }

        public static void DisplayResults(ParsedData courencyPair)
        {
            System.Console.WriteLine($"{courencyPair.AmountFrom} {courencyPair.CurencyFrom} = {courencyPair.AmountTo} {courencyPair.CurencyTo}");
        }

        public static ParsedData ParseData(string dataToParse)
        {
            if(null == dataToParse) throw new Exception("It is not expected currency pair format!");

            Regex regex = new Regex(@"[A-z]{3}[\/][A-z]{3}\s+\d+\.?\d*");
            string validData = regex.Match(dataToParse).ToString();

            if(validData == "") throw new Exception("It is not expected currency pair format!");

            ParsedData parsedData = SeparateCurrencies(validData);
            parsedData.AmountFrom = SepareteAmount(validData);
            
            return parsedData;
        }

        private static decimal SepareteAmount(string data)
        {
            Regex regex = new Regex(@"\d+\.?\d*");
            string parsedAmount = regex.Match(data).ToString();
            if(parsedAmount != "")
            {
                return Convert.ToDecimal(parsedAmount);
            }
            return 0m;
        }

        private static ParsedData SeparateCurrencies(string data)
        {
            Regex regex = new Regex(@"[A-z]{3}");
            string[] currencies = regex.Matches(data)
                .OfType<Match>()
                .Select(m => m.Groups[0].Value)
                .ToArray();
            ParsedData parsedData = new ParsedData();
            parsedData.CurencyFrom = currencies[0].ToUpper();
            parsedData.CurencyTo = currencies[1].ToUpper();
            return parsedData;
        }
    }
}