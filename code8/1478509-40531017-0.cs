        public static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int counter = 0; counter < 10; counter++)
            {
                StringBuilder numberBuilder = new StringBuilder();
                foreach (int number in numbers)
                {
                    numberBuilder.Append(number + " ");
                }
                sb.Insert(0, numberBuilder.ToString());
            }
            Console.WriteLine(sb.ToString());
        }
