    public class SumModel
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public int Sum { get; set; }
        public SumModel() { }
        public SumModel(int firstNumber, int secondNumber) {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            Sum = firstNumber + secondNumber;
        }
    }
