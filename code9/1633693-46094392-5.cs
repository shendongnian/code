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
        static public void Example(NumberElement ne)
        {
            //Line 1
            ne.AddNumbers(6);
            ne.AddNewLine();
            //Line 2
            ne.AddSpaces(5);
            ne.AddNumber(6);
            ne.AddNewLine();
            //Line 3
            ne.AddNumbers(4);
            ne.AddSpace();
            ne.AddNumber(6);
            ne.AddNewLine();
            //Line 4
            ne.AddNumber(1);
            ne.AddSpaces(2);
            ne.AddNumber(4);
            ne.AddSpace();
            ne.AddNumber(6);
            ne.AddNewLine();
            //Line 5
            ne.AddNumber(1);
            ne.AddSpaces(2);
            ne.AddNumber(4);
            ne.AddSpace();
            ne.AddNumber(6);
            ne.AddNewLine();
            //Line 6
            ne.AddNumber(1);
            ne.AddSpaces(2);
            ne.AddNumber(4);
            ne.AddSpace();
            ne.AddNumber(6);
            ne.AddNewLine();
            //Line 6
            ne.AddNumber(1);
            ne.AddSpace();
            ne.AddNumber(3);
            ne.AddNumber(4);
            ne.AddSpace();
            ne.AddNumber(6);
            ne.AddNewLine();
            //Line 7
            ne.AddNumber(1);
            ne.AddSpaces(4);
            ne.AddNumber(6);
            ne.AddNewLine();
            //Line 8
            ne.AddNumbers(6);
        }
        static void Main(string[] args)
        {
            NumberElement ne = new NumberElement();
            Example(ne);
            Console.WriteLine(ne);
        }
    }
