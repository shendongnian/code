    public class MySpliter
    {
        public List<string> PositiveSplit(string text)
        {
            List<string> temp = new List<string>();
            string[] splitedText = text.Split(' ');
            bool positive = true;
            foreach (string t in splitedText)
            {
                if (t.Equals("+"))
                {
                    positive = true;
                }
                else if (t.Equals("-"))
                {
                    positive = false;
                }
                else if (positive)
                {
                    temp.Add(t);
                }
            }
            return temp;
        }
        public List<string> NegativeSplit(string text)
        {
            List<string> temp = new List<string>();
            string[] splitedText = text.Split(' ');
            bool negative = false;
            foreach (string t in splitedText)
            {
                if (t.Equals("+"))
                {
                    negative = false;
                }
                else if (t.Equals("-"))
                {
                    negative = true;
                }
                else if (t.Equals("-"))
                {
                    negative = true;
                }
                else if (negative)
                {
                    temp.Add(t);
                }
            }
            return temp;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MySpliter ms = new MySpliter();
            string InputStr = "DIM H + QUT OF PIP DIM - DIM L + XYZ - ABC";
            List<string> positive = ms.PositiveSplit(InputStr);
            List<string> negative = ms.NegativeSplit(InputStr);
            Console.WriteLine("Positive");
            positive.ForEach(text => Console.Write(text + " "));
            Console.WriteLine("");
            Console.WriteLine("Negative");
            negative.ForEach(text => Console.Write(text + " "));
            Console.WriteLine("");
        }
    }
