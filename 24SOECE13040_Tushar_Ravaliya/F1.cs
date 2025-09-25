using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24SOECE13040_Tushar_Ravaliya
{
    public partial class F1 : Form
    {
        public F1()
        {
            InitializeComponent();
        }

        private void ans_Click(object sender, EventArgs e)
        {
            int num1 = Convert.ToInt32(textBox1.Text);
            int num2 = Convert.ToInt32(textBox2.Text);
            string add = radioButton1.Text;
            string sub = radioButton3.Text;
            string mul = radioButton2.Text;
            string div = radioButton4.Text;
            if (add == "adition")
            {
                int answer1 = num1 + num2;
                answer.Text = Convert.ToString(answer1);
            }
            if (sub == "Subtraction")
            {
                int answer1 = num1 - num2;
                answer.Text = Convert.ToString(answer1);
            }
            if (mul == "Multiplication")
            {
                int answer1 = num1 * num2;
                answer.Text = Convert.ToString(answer1);
            }
            if (div == "Division")
            {
                int answer1 = num1 / num2;
                answer.Text = Convert.ToString(answer1);
            }
        }
    }
}
