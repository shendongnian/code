    public class NumberElement
    {
        private StringBuilder sb;
        public NumberElement()
        {
            sb = new StringBuilder();
        }
        public void AddNumbers(int Numbers)
        {
            for(int i = 1; i < Numbers + 1; i++)
            {
                AddNumber(i);
            }
        }
        public void AddSpaces(int SpaceNumber)
        {
            for (int i = 1; i < SpaceNumber + 1; i++)
            {
                AddSpace();
            }
        }
        public void AddNumber(int number)
        {
                sb.Append(number + " ");
        }
        public void AddSpace()
        {
                sb.Append("  ");
        }
        public void AddNewLine()
        {
            sb.Append("\n");
        }
        public override string ToString()
        {
            return sb.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            NumberElement ne = new NumberElement();
            ne.AddNumbers(6);
            ne.AddNewLine();
            ne.AddSpaces(5);
            ne.AddNumber(6);
            ne.AddNewLine();
            ne.AddNumbers(4);
            ne.AddSpace();
            ne.AddNumber(6);
            Console.WriteLine(ne);
        }
    }
