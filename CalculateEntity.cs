namespace Calculator
{
    public abstract class CalculateEntity
    {
        public abstract string Calculate(string expression);
        public abstract string Operate(string v1, string v2, string oper);
    }
}
