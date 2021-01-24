        static void Main(string[] args)
        {
            string[] test = { "t1", "t2", "t3" };
            List<object> combined = new List<object> {1};
            combined.AddRange(test);
            combined.Add("Hello");
            TestArray(combined.ToArray());
        }
        static void TestArray(params object[] array)
        {
            foreach (var value in array)
            {
                Console.WriteLine(value);
            }
            Console.ReadLine();
        }
