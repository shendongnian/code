        static void Benchmark(string description, StringDelegate d, int times, string text)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int j = 0; j < times; j++)
            {
                d(text);
            }
            sw.Stop();
            Console.WriteLine("{0} Ticks {1} : called {2} times.", sw.ElapsedTicks, description, times);
        }
        public static string ReverseArray(string text)
        {
            if (text == null) return null;
            // this was posted by petebob as well 
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }
        public static string ReverseXor(string s)
        {
            char[] charArray = s.ToCharArray();
            int len = s.Length - 1;
            for (int i = 0; i < len; i++, len--)
            {
                charArray[i] ^= charArray[len];
                charArray[len] ^= charArray[i];
                charArray[i] ^= charArray[len];
            }
            return new string(charArray);
        }
        public static string ReverseClassic(string s)
        {
            char[] charArray = s.ToCharArray();
            int len = s.Length-1;
            for (int i = 0; i < len; i++, len--)
            {
                char temp = charArray[len];
                charArray[len] = charArray[i];
                charArray[i] = temp;
            }
            return new string(charArray);
        }
        public static string StringOfLength(int length)
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))));
            }
            return sb.ToString();
        }
        static void Main(string[] args)
        {
            
            int[] lengths = new int[] { 1, 10, 100, 1000, 10000, 100000 };
            foreach (int l in lengths)
            {
                int iterations = 10000;
                string text = StringOfLength(l);                
                Benchmark(String.Format("Classic (Length: {0})", l), ReverseClassic, iterations, text);
                Benchmark(String.Format("Array (Length: {0})", l), ReverseArray, iterations, text);
                Benchmark(String.Format("Xor (Length: {0})", l), ReverseXor, iterations, text);
                Console.WriteLine();
            }
            Console.Read();
        }
