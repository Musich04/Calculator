namespace Calculator
{
    public abstract class FunctionModel
    {
        protected string _expression;
        public string Expression => _expression;

        protected int _expressionIndex;
        public int ExpressionIndex => _expressionIndex;

        public FunctionModel(string expression)
        {
            _expression = expression;
            _expression = expression.Replace(" ", "");
            _expression = _expression[0] + _expression.Substring(1).Replace("-", "+-");
            _expressionIndex = 0;
        }

        public abstract void SwitchIndex();
        public abstract string GetOperand();
        public abstract string GetOperation();
        public abstract bool IsCorrectFunction();
        
    }
}
