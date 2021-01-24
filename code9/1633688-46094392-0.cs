    public class NumberElement
    {
        StringBuilder sb;
        public NumberElement()
        {
            sb = new StringBuilder();
        }
        public void AddNumber(char number)
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
            StringBuilder sb = new StringBuilder();
            NumberElement ne = new NumberElement();
            ne.AddNumber('1');
            ne.AddNumber('2');
            ne.AddNewLine();
            ne.AddSpace();
            ne.AddNumber('2');
            Console.WriteLine(ne);
        }
    }
