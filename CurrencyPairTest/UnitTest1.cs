using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyPair;

namespace CurrencyPairTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string text = "Hello world!";
            Assert.ThrowsException<Exception>(
              () => Utility.Console.ParseData(text)
            );
        }

        [TestMethod]
        public void TestMethod2()
        {
            string text = "EUR/DKK l";
            Assert.ThrowsException<Exception>(
              () => Utility.Console.ParseData(text)
            );
        }

        [TestMethod]
        public void TestMethod3()
        {
            string text = "EUR/DKK -1";
            Assert.ThrowsException<Exception>(
              () => Utility.Console.ParseData(text)
            );
        }

        [TestMethod]
        public void TestMethod4()
        {
            string text = null;
            Assert.ThrowsException<Exception>(
              () => Utility.Console.ParseData(text)
            );
        }

        [TestMethod]
        public void TestMethod5()
        {
            string text = "EUR/DKK 1";
            ParsedData parsedData = Utility.Console.ParseData(text);
            ParsedData currencyPair = new ParsedData();
            currencyPair.CurencyFrom = "EUR";
            currencyPair.CurencyTo = "DKK";
            currencyPair.AmountFrom = 1m;
            bool isEqual = ObjectsValuesAreEqual(currencyPair, parsedData);
            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void TestMethod6()
        {
            string text = "EUR/DKK 1";
            ParsedData currencyPair = Utility.Console.ParseData(text);
            Exchange exchange = new Exchange();
            decimal result = exchange.CalculateAmount(currencyPair);
            Assert.AreEqual(7.4394m, result);
        }

        [TestMethod]
        public void TestMethod7()
        {
            string text = "GBP/GBP 10";
            ParsedData currencyPair = Utility.Console.ParseData(text);
            Exchange exchange = new Exchange();
            currencyPair.AmountTo = exchange.CalculateAmount(currencyPair);
            Assert.AreEqual(currencyPair.AmountFrom, currencyPair.AmountTo);
        }

        [TestMethod]
        public void TestMethod8()
        {
            ParsedData currencyPair = new ParsedData();
            currencyPair.CurencyFrom = "eur";
            currencyPair.CurencyTo = "ABC";
            currencyPair.AmountFrom = 5m;
            Exchange exchange = new Exchange();
            Assert.ThrowsException<Exception>(
                () => exchange.CalculateAmount(currencyPair)
            );
        }

        [TestMethod]
        public void TestMethod9()
        {
            ParsedData currencyPair = new ParsedData();
            currencyPair.CurencyFrom = "CBA";
            currencyPair.CurencyTo = "DKK";
            currencyPair.AmountFrom = 15m;
            Exchange exchange = new Exchange();
            Assert.ThrowsException<Exception>(
                () => exchange.CalculateAmount(currencyPair)
            );
        }

        [TestMethod]
        public void TestMethod10()
        {
            ParsedData currencyPair = new ParsedData();
            currencyPair.CurencyFrom = null;
            currencyPair.CurencyTo = null;
            currencyPair.AmountFrom = 15m;
            Exchange exchange = new Exchange();
            Assert.ThrowsException<Exception>(
                () => exchange.CalculateAmount(currencyPair)
            );
        }


        private bool ObjectsValuesAreEqual(ParsedData objectA, ParsedData objectB)
        {
            if (objectA.CurencyFrom != objectB.CurencyFrom) return false;
            if (objectA.CurencyTo != objectB.CurencyTo) return false;
            if (objectA.AmountFrom != objectB.AmountFrom) return false;
            if (objectA.AmountTo != objectB.AmountTo) return false;
            return true;
        }
    }
}
