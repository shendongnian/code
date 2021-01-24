    public class CalculationHistory
    {
        public double firstNumber { get; set; }
        public double secondNumber { get; set; }
        public string stringOperation { get; set; }
        public CalculationHistory(double firstNum, double secondNum, string op)
        {
            firstNumber = firstNum;
            secondNumber = secondNum;
            stringOperation = op;
        }
    }
