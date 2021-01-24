    public class NumberElement
    {
        private StringBuilder sb;
        public NumberElement()
        {
            sb = new StringBuilder();
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
            for(int i = 1; i < 7; i++)
            {
                ne.AddNumber(i);
            }
            ne.AddNewLine();
            for (int i = 0; i < 5; i++)
            {
                ne.AddSpace();
            }
            ne.AddNumber(6);
            ne.AddNewLine();
            for (int i = 1; i < 5; i++)
            {
                ne.AddNumber(i);
            }
            ne.AddSpace();
            ne.AddNumber(6);
            Console.WriteLine(ne);
        }
    }
