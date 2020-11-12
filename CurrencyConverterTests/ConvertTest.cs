using System;
using CurrencyConverterForms;
using CurrencyConverterLibreria;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace CurrencyConverterTests
{

    [TestClass]
    public class ConvertTest
    {
        [TestMethod]
        public void ConversionBreadth()
        {
            decimal result;
            decimal amount;
            CurrencyType fromCur;
            CurrencyType toCur;

            amount = 100.0M;
            fromCur = CurrencyType.US;
            toCur = CurrencyType.US;
            result = FrmCurrency.CurrencyConvert(amount, fromCur, toCur);
            Assert.AreEqual(100.0M, result, "US to US should be no change");

            fromCur = CurrencyType.UK;
            toCur = CurrencyType.UK;
            result = FrmCurrency.CurrencyConvert(amount, fromCur, toCur);
            Assert.AreEqual(100.0M, result, "UK to UK should be no change");

            fromCur = CurrencyType.AUS;
            toCur = CurrencyType.AUS;
            result = FrmCurrency.CurrencyConvert(amount, fromCur, toCur);
            Assert.AreEqual(100.0M, result, "AUS to AUS should be no change");

            decimal expected;
            fromCur = CurrencyType.US;
            toCur = CurrencyType.AUS;
            result = FrmCurrency.CurrencyConvert(amount, fromCur, toCur);
            expected = amount * 2;
            Assert.AreEqual(expected, result, "US to AUS is incorrect");

            fromCur = CurrencyType.UK;
            toCur = CurrencyType.AUS;
            result = FrmCurrency.CurrencyConvert(amount, fromCur, toCur);
            expected = amount / 0.5M * 2;
            Assert.AreEqual(expected, result, "UK to AUS is incorrect");
        }

        [TestMethod]
        public void ConvertTo()
        {
            ConvertibleCurrency currency;
            decimal result;
            decimal expected;

            currency = new ConvertibleCurrency(CurrencyType.US, 100.0M);
            result = currency.ConvertTo(CurrencyType.US);
            Assert.AreEqual(100.0M, result, "US to US should be no change");

            currency = new ConvertibleCurrency(CurrencyType.AUS, 100.0M);
            result = currency.ConvertTo(CurrencyType.UK);
            expected = 100.0M / 2 * 0.5M;
            Assert.AreEqual(expected, result, "AUS to UK incorrect result");
        }

    }
}
