using System.Collections.Generic;
using System.Windows.Forms;

namespace Calculator
{
    public class Controller
    {
        private CalculatorModel _calculator;
        private string _text;

        public Controller()
        {
            _calculator = new CalculatorModel();
        }

        public string ReadResult()
        {
            string result = _calculator.Calculate(_text);
            return result;
        }

        public void WriteTo(string text)
        {
            _text = text;
        }
    }
}
