    class Program
        {
            static void Main(string[] args)
            {
                Func<object>[] d = new Func<object>[] { ReturnFive, ReturnTen, ReturnTwentyTwo, returnDoubles };
        
                foreach (object i in GetAllReturnValues<object>(d))
                    Console.WriteLine(i);
                Console.ReadKey();
        
        
            }
        
            static IEnumerable<object> GetAllReturnValues<TArgs>(Func<object>[] d)
            {
        
                List<int> ints = new List<int>();
                foreach (Func<object> item in d)
                    yield return item();
        
        
            }
        
            static object ReturnFive() { return 5; }
            static object ReturnTen() { return 10; }
            static object ReturnTwentyTwo() { return 22; }
            static object returnDoubles() { return 1.0; }
        
        }
