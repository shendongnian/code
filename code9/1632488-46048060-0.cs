        static void Main(string[] args)
        {
            string s = "ABC0000";
            for(int i = 0; i < 10; i++)
            {
                int index = Int16.Parse(s.Substring(3, s.Length - 3)) + 1;
                s = s.Substring(0, 3) + $"{index:D4}";
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
