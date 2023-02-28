using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class Function : FunctionModel
    {
        private IReadOnlyList<string> _permittedOperations = new List<string>();
        private IReadOnlyList<string> _permittedNumbers = new List<string>();
        private IReadOnlyList<string> _permittedSymbols = new List<string>();
        private const string _coma = ",";
        private const string _minus = "-";

        public Function(IReadOnlyList<string> permittedOperations, IReadOnlyList<string> permittedNumbers, string expression) : base(expression)
        {
            _permittedOperations = permittedOperations;
            _permittedNumbers = permittedNumbers;
            _permittedSymbols = DefinePermittedSymbols(_permittedNumbers, _permittedOperations);
        }

        public override string GetOperand()
        {
            string operand = string.Empty;

            while (_expressionIndex < _expression.Length && !_permittedOperations.Contains(_expression[_expressionIndex].ToString()))
            {
                operand += _expression[_expressionIndex].ToString();
                SwitchIndex();
            }

            return operand;
        }

        public override string GetOperation() => _expression[_expressionIndex].ToString();
        public override void SwitchIndex() => _expressionIndex++;

        public override bool IsCorrectFunction()
        {   
            if (!IsCorrectSymbols())
                return false;

            int index = 0;

            while (index < _expression.Length)
            {
                if (!IsCorrectOperation(index))
                    return false;
                
                if (!IsCorrectMinus(index))
                    return false;
                
                if (!IsCorrectPunctuation(index))
                    return false;

                index++;
            }

            if (!HasOperation())
                return false;

            return true;
        }

        private bool IsCorrectSymbols()
        {
            if (_expression.Any(x => !_permittedSymbols.Contains(x.ToString())))
                return false;

            return true;
        }

        private bool IsCorrectOperation(int index)
        {
            if (_permittedOperations.Contains(_expression[index].ToString()))
            {
                if (index > 0 && index < _expression.Length - 1)
                {
                    if (_permittedOperations.Contains(_expression[index - 1].ToString()) || _permittedOperations.Contains(_expression[index + 1].ToString()))
                        return false;
                }
                else return false;
            }

            return true;
        }

        private bool IsCorrectMinus(int index)
        {
            if (_expression[index].ToString() == _minus)
            {
                if (index == _expression.Length - 1)
                    return false;
                else
                {
                    if (!_permittedNumbers.Contains(_expression[index + 1].ToString()))
                        return false;
                }
            }

            return true;
        }

        private bool IsCorrectPunctuation(int index)
        {
            if (_expression[index].ToString() == _coma)
            {
                if (index > 0 && index < _expression.Length - 1)
                {
                    if (!(_permittedNumbers.Contains(_expression[index - 1].ToString()) && _permittedNumbers.Contains(_expression[index + 1].ToString())))
                        return false;
                }
                else
                    return false;
            }

            return true;
        }

        private bool HasOperation()
        {
            if (!_expression.Any(x => _permittedOperations.Contains(x.ToString())))
                return false;

            return true;
        }

        private IReadOnlyList<string> DefinePermittedSymbols(IReadOnlyList<string> permittedNumbers, IReadOnlyList<string> permittedOperations)
        {
            List<string> permittedSymbols = new List<string>();

            permittedSymbols.AddRange(permittedNumbers);
            permittedSymbols.AddRange(permittedOperations);
            permittedSymbols.Add(_coma);
            permittedSymbols.Add(_minus);

            return permittedSymbols;
        }
    }
}
