using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurrencyConverterLibreria;


namespace CurrencyConverterForms
{
  
    public partial class FrmCurrency : Form
    {
        public FrmCurrency()
        {
            InitializeComponent();
        }


        private void ConvertButton_Click(object sender, System.EventArgs e)
        {
            decimal converted = 0.0M;
            decimal initial = 0.0M;
            BaseCurrency fromCur;
            BaseCurrency toCur;

            initial = Convert.ToDecimal(Amount.Text);
            if (FromUK.Checked)
            {
                fromCur = new UKCurrency();
            }
            else if (FromAUS.Checked)
            {
                fromCur = new AUSCurrency();
            }
            else
            {
                fromCur = new USCurrency();
            }
            if (ToUK.Checked)
            {
                toCur = new UKCurrency();
            }
            else if (ToAus.Checked)
            {
                toCur = new AUSCurrency();
            }
            else
            {
                toCur = new USCurrency();
            }
            converted = ConvertibleCurrency.CurrencyConvert(initial, fromCur, toCur);
            Result.Text = converted.ToString();
        }

        //public static decimal CurrencyConvert(decimal amount, CurrencyType fromCur, CurrencyType toCur)
        //{
           // decimal converted = 0.0M;
           // ConvertibleCurrency currency = new ConvertibleCurrency(fromCur, amount);
          //  converted = currency.ConvertTo(toCur);
         //   return converted;
        //}


    }
}
