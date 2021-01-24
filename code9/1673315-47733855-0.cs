    class Program
    {
        static void Main(string[] args)
        {
            string input = "130=1612345";
            string[] inputs = input.Split("=".ToCharArray());
            if (inputs.Length == 2)
            {
                string strSum = inputs[0].Trim();
                string strDigits = inputs[1].Trim();
                int sum, values;
                if (int.TryParse(strSum, out sum) && int.TryParse(strDigits, out values))
                {
                    Console.WriteLine("Input: " + input);
                    List<string> solutions = FindEquation(sum, values);
                    Console.WriteLine("Solutions Found: " + solutions.Count.ToString());
                    for(int i = 0; i < solutions.Count; i++)
                    {
                        Console.WriteLine("Solution #" + (i + 1).ToString() + ": " + solutions[i]);
                    }
                }
            }
            
            Console.WriteLine("");
            Console.Write("Press [Enter] to exit...");
            Console.ReadLine();
        }
        private static List<string> FindEquation(int sum, int values)
        {
            List<string> solutions = new List<string>();
          
            string binary;
            string[] addends;
            int iterationSum;
            StringBuilder iteration = new StringBuilder();
            char[] digits = values.ToString().ToCharArray();
            int possibilities = (int)Math.Pow((double)2, (double)(digits.Length - 1));
            for(int i=0; i < possibilities; i++)
            {
                binary = Convert.ToString(i, 2).PadLeft(digits.Length - 1, '0');
                iteration.Clear();
                for(int j=0;j<digits.Length; j++)
                {
                    iteration.Append(digits[j]);
                    if((j < (digits.Length -1)) && (binary.Substring(j, 1) == "1"))
                    {
                        iteration.Append("+");
                    }
                }
                addends = iteration.ToString().Split("+".ToCharArray());
                iterationSum = 0;
                foreach(string addend in addends)
                {
                    iterationSum = iterationSum + int.Parse(addend);
                }
                if (iterationSum == sum)
                {
                    solutions.Add(sum.ToString() + "=" + iteration.ToString());
                }
            }
            return solutions;
        }
    }
