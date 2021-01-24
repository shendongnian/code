    public class Calculator
    {
        public double Result { get; set; }
        public void Calculate(string operation, double operand)
        {
            switch (operation)
            {
                case "+":
                    Result = result + operand;
                    break;
                case "-":
                    Result = result - operand;
                    break;
                case "*":
                    Result = result * operand;
                    break;
                case "/":
                    Result = result / operand;
                    break;
                case "Mod":
                    Result = result % operand;
                    break;
                case "Exp":
                    Result = Math.Exp(operand * Math.Log(Result * 4));
                    break;
                default:
                    break;
            }
        }
    }
