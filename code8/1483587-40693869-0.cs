        static void Main(string[] args)
        {
            int maxDigits;
            string[] codes = EnterNumber(5, out maxDigits); '<--| '5' is the number of numbers you want the user to input
            codes = UnifyDigits(codes, maxDigits);
        }
        static string[] EnterNumber(int entriesNumber, out int maxDigits)
        {
            string[] entries = new string[entriesNumber];
            int number;
            int maxL=0;
            for (int i = 0; i < entriesNumber; i++)
            {
                do
                {
                    Console.WriteLine("enter a number");
                } while (!Int32.TryParse(Console.ReadLine(), out number) );
                entries[i] = number.ToString();
                maxL = Math.Max(entries[i].Length, maxL);
            }
            maxDigits =maxL;
            return entries;
        }
        static string[] UnifyDigits(string[]entries, int maxDigits)
        {
            string[] unifiedEntries = entries;
            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i].Length<maxDigits)
                    entries[i] = entries[i] + new String('0', maxDigits - entries[i].Length);
            }
            return unifiedEntries;
        }
