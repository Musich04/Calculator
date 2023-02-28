using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Stack : StackModel
    {
        private List<string> _permittedOperations = new List<string>();

        public Stack(List<string> permittedOperations) : base()
        {
            _permittedOperations = permittedOperations;
        }

        public override void SwitchOperation(string operation, Function func)
        {
            while (_permittedOperations.Contains(_stack[_stackIndex])
                        && _permittedOperations.IndexOf(func.Expression[func.ExpressionIndex].ToString()) > _permittedOperations.IndexOf(_stack[_stackIndex]))
            {
                _stack[_stackIndex + 1] = _stack[_stackIndex];
                _stackIndex--;
            }

            _stack[_stackIndex + 1] = operation;
            func.SwitchIndex();
        }

        public override void SwitchOperand(string operand, string operation)
        {
            int index = _stack.LastIndexOf(operation.ToString());

            UpdateIndex();

            while (_stackIndex > index)
            {
                _stack[_stackIndex] = _stack[_stackIndex - 1];
                _stackIndex--;
            }

            _stack[index] = operand;
        }

        public override string GetResult(CalculatorModel calculator)
        {
            string result = string.Empty;

            while (_stack.Count > 1)
            {
                int firstOperationIndex = _stack.Count;

                foreach (string str in _permittedOperations)
                {
                    if (_stack.IndexOf(str) > 0 && _stack.IndexOf(str) < firstOperationIndex)
                        firstOperationIndex = _stack.IndexOf(str);
                }

                string f1 = _stack[firstOperationIndex - 2];
                string f2 = _stack[firstOperationIndex - 1];
                string operation = _stack[firstOperationIndex];
                string diff = calculator.Operate(f1, f2, operation);

                _stack.RemoveAt(firstOperationIndex);
                _stack.RemoveAt(firstOperationIndex - 1);
                _stack[firstOperationIndex - 2] = diff;

                result += String.Join(",", _stack.ToArray()) + Environment.NewLine;
            }

            return result;
        }
    }
}
