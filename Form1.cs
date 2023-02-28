using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private Controller _controller = new Controller();

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void functionBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            _controller.WriteTo(functionBox.Text);
            functionBox.Text += Environment.NewLine + _controller.ReadResult();
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            functionBox.Text += "1";
        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {
            functionBox.Text += "2";
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {
            functionBox.Text += "3";
        }

        private void buttonFour_Click(object sender, EventArgs e)
        {
            functionBox.Text += "4";
        }

        private void buttonFive_Click(object sender, EventArgs e)
        {
            functionBox.Text += "5";
        }

        private void buttonSix_Click(object sender, EventArgs e)
        {
            functionBox.Text += "6";
        }

        private void buttonSeven_Click(object sender, EventArgs e)
        {
            functionBox.Text += "7";
        }

        private void buttonEight_Click(object sender, EventArgs e)
        {
            functionBox.Text += "8";
        }

        private void buttonNine_Click(object sender, EventArgs e)
        {
            functionBox.Text += "9";
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            functionBox.Text += "0";
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            functionBox.Text += "+";
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            functionBox.Text += "-";
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            functionBox.Text += "*";
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            functionBox.Text += "/";
        }

        private void buttonCLear_Click(object sender, EventArgs e)
        {
            functionBox.Clear();
        }

        private void buttonDegree_Click(object sender, EventArgs e)
        {
            functionBox.Text += "^";
        }

        private void buttonSquareRoot_Click(object sender, EventArgs e)
        {
            functionBox.Text += "^0,5";
        }

        private void buttonComa_Click(object sender, EventArgs e)
        {
            functionBox.Text += ",";
        }

        private void buttonDeleteOne_Click(object sender, EventArgs e)
        {
            if (functionBox.Text.Length > 0)
                functionBox.Text = functionBox.Text.Remove(functionBox.Text.Length - 1, 1);
        }
    }
}
