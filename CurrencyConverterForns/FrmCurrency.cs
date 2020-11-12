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
               

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            decimal converted = 0.0M;
            decimal initial = 0.0M;

            CurrencyType fromCur = CurrencyType.US;
            CurrencyType toCur = CurrencyType.US;

            initial = Convert.ToDecimal(Amount.Text);

            if (FromUK.Checked)
            {
                fromCur = CurrencyType.UK;
            }
            else if (FromAUS.Checked)
            {
                fromCur = CurrencyType.AUS;
            }

            if (ToUK.Checked)
            {
                toCur = CurrencyType.UK;
            }
            else if (ToAus.Checked)
            {
                toCur = CurrencyType.AUS;
            }
            converted = CurrencyConvert(initial, fromCur, toCur);
            Result.Text = converted.ToString();
        }
        public static decimal CurrencyConvert(decimal amount, CurrencyType fromCur, CurrencyType toCur)
        {
            decimal converted = 0.0M;
            ConvertibleCurrency currency = new ConvertibleCurrency(fromCur, amount);
            converted = currency.ConvertTo(toCur);
            return converted;
        }


    }
}
