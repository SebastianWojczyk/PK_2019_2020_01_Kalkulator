using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Kalkulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //żeby było postarcie programu policzone dla wartości domyślnych (1+1)
            sourceValueChanged(null, null);
        }

        private void sourceValueChanged(object sender, EventArgs e)
        {
            bool isOK = true;

            textBoxValue1.BackColor = System.Drawing.SystemColors.Window;
            textBoxValue2.BackColor = System.Drawing.SystemColors.Window;
            comboBoxSign.BackColor = System.Drawing.SystemColors.Window;

            if (!Int32.TryParse(textBoxValue1.Text, out int x))
            {
                textBoxValue1.BackColor = Color.Red;
                isOK = false;
            }
            if (!Int32.TryParse(textBoxValue2.Text, out int y))
            {
                textBoxValue2.BackColor = Color.Red;
                isOK = false;
            }
            if (!(new String[] { "+", "-", "*", "/" }).Contains(comboBoxSign.Text))
            {
                comboBoxSign.BackColor = Color.Red;
                isOK = false;
            }

            if (isOK)
            {
                switch (comboBoxSign.Text)
                {
                    case "+":
                        textBoxResult.Text = (x + y).ToString();
                        break;
                    case "-":
                        textBoxResult.Text = (x - y).ToString();
                        break;
                    case "*":
                        textBoxResult.Text = (x * y).ToString();
                        break;
                    case "/":
                        if (y != 0)
                        {
                            textBoxResult.Text = (x / y).ToString();
                        }
                        else
                        {
                            textBoxValue2.BackColor = Color.Red;
                            textBoxResult.Text = "";
                        }
                        break;
                }
            }
            else
            {
                textBoxResult.Text = "";
            }

        }
    }
}
