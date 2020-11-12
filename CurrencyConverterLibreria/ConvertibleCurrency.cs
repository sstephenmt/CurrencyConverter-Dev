using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyConverterLibreria;

namespace CurrencyConverterLibreria
{
    public enum CurrencyType
    {
        US,
        AUS,
        UK,
    }
    public class ConvertibleCurrency
    {
        private decimal AusInUS = 2;
        private decimal UKInUS = 0.5M;

        private decimal amount;
        private CurrencyType currency;

        public ConvertibleCurrency(CurrencyType type, decimal val)
        {
            currency = type;
            amount = val;
        }
         
        public decimal ConvertTo(CurrencyType type)
        {
            decimal converted = ConvertToUS();
            converted = ConvertFromUS(type, converted);
            return converted;
        }
         

        private decimal ConvertToUS()
        {
            decimal converted = 0.0M;
            converted = amount;

            if (currency == CurrencyType.UK)
            {
                converted = converted / UKInUS;
            }
            else if (currency == CurrencyType.AUS)
            {
                converted = converted / AusInUS;
            }
            return converted;
        }

        private decimal ConvertFromUS(CurrencyType type, decimal USAmount)
        {
            decimal converted = 0.0M;
            converted = USAmount;

            if (type == CurrencyType.UK)
            {
                converted = converted * UKInUS;
            }
            else if (type == CurrencyType.AUS)
            {
                converted = converted * AusInUS;
            }
            return converted;
        }


    }
}
