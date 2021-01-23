        static int GetYearFromTextLine(string s)
        {
            string [] words = s.Split(' ');
            foreach (string w in words)
            {
                int number = 0;
                if (int.TryParse(w, out number))
                {
                    // assume the first number found over "1900" must be a year
                    // you can modify this test yourself
                    if (number >= 1900)
                    {
                        return number;
                    }
                }
            }
            return 0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(GetYearFromTextLine("Math problems galore 2013 Round 02 directed problems"));
        }
