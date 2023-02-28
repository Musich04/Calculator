using System.Collections.Generic;

namespace Calculator
{
    public abstract class StackModel
    {
        protected List<string> _stack = new List<string>();
        protected int _stackIndex;

        public StackModel()
        {
            _stack = new List<string>();
            _stackIndex = 0;
        }

        public void Add(string value) => _stack.Add(value);
        public string[] ConvertToArray() => _stack.ToArray();
        public void UpdateIndex() => _stackIndex = _stack.Count - 1;

        public abstract void SwitchOperand(string operand, string operation);
        public abstract void SwitchOperation(string operation, Function func);
        public abstract string GetResult(CalculatorModel calculator);
    }
}
