using System;
using System.Collections.Generic;

namespace Calculator
{
    public class CalculatorModel : CalculateEntity
    {
        private List<string> _permittedOperations = new List<string>() { "+", "*", "/", "^" };
        private IReadOnlyList<string> _permittedNumbers = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public override string Calculate(string expression)
        {
            Function function = new Function(_permittedOperations, _permittedNumbers, expression);
            StackModel stack = new Stack(_permittedOperations);

            string operand;
            string lastOperation = string.Empty;
            string result = string.Empty;

            if (!function.IsCorrectFunction())
                return Environment.NewLine + "ERROR";

            while (function.ExpressionIndex < function.Expression.Length)
            {
                stack.UpdateIndex();

                // First symbol ?
                if (function.ExpressionIndex == 0)
                {
                    string firstOperand = function.GetOperand();
                    stack.Add(firstOperand);
                    continue;
                }

                // Operation or Operand ?
                if (_permittedOperations.Contains(function.Expression[function.ExpressionIndex].ToString())) // Operation
                {
                    // Write to stack
                    lastOperation = function.GetOperation();
                    stack.Add(lastOperation);

                    // Switch by Priority
                    stack.SwitchOperation(lastOperation, function);
                }
                else
                {
                    // Write to stack
                    operand = function.GetOperand();
                    stack.Add(operand);

                    // Switch
                    stack.SwitchOperand(operand, lastOperation);
                }

                result += String.Join(",", stack.ConvertToArray()) + Environment.NewLine;
            }

            result += stack.GetResult(this);
            return result;
        }

        public override string Operate(string v1, string v2, string oper)
        {
            string result;

            switch (oper)
            {
                case "+": result = (Convert.ToDouble(v1) + Convert.ToDouble(v2)).ToString(); return result;
                case "*": result = (Convert.ToDouble(v1) * Convert.ToDouble(v2)).ToString(); return result;
                case "/": result = (Convert.ToDouble(v1) / Convert.ToDouble(v2)).ToString(); return result;
                case "^": result = (Math.Pow(Convert.ToDouble(v1), Convert.ToDouble(v2))).ToString(); return result;
                default: throw new ArgumentException();
            }
        }


    }
}
