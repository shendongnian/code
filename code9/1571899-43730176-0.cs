            static void Main(string[] args)
            {
                string[] test = {"0", "1", "2", "3"};
                int[] intArr = test.Select(s1 => Convert.ToInt32(s1)).ToArray();
                int output = intArr.Aggregate((x,y) => x+y);
                Console.WriteLine(output);
                Console.ReadKey();
    
            }
