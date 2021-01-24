    public class MySpliter
    {
        public List<string> PositiveSplit(string text)
        {
            List<string> temp = new List<string>();
            string[] splitedText = text.Split(' ');
            bool positive = true;
            foreach (string t in splitedText)
            {
                
                if(t.Equals("+"))
                {
                    positive = true;
                }
                else if (t.Equals("-"))
                {
                    positive = false;
                }
                else if (positive && !t.Equals("+"))
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
        }
    }
