    public class Calculator
    {
        public double Result { get; set; }
        public void Calculate(string operation, double operand)
        {
            switch (operation)
            {
                case "+":
                    Result = Result + operand;
                    break;
                case "-":
                    Result = Result - operand;
                    break;
                case "*":
                    Result = Result * operand;
                    break;
                case "/":
                    Result = Result / operand;
                    break;
                case "Mod":
                    Result = Result % operand;
                    break;
                case "Exp":
                    Result = Math.Exp(operand * Math.Log(Result * 4));
                    // Did you want this instead?
                    // Result = Math.Pow(Result, operand);
                    break;
                default:
                    break;
            }
        }
    }
