        class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new StringA('B', 15));
            Console.Read();
        }
    }
    class StringA
    {
        string res = "";
        public StringA(char x, int y)
        {
            string ConvertedChar = Convert.ToString(x);
            for (int i = 0; i < y; i++)
            {
                res += ConvertedChar;
            }
        }
        public override string ToString()
        {
            return res;
        }
    }
