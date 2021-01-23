    static void Main(string[] args)
            {
                var start = DateTime.Now;
                EnTest();
                var end = DateTime.Now;
    
                var firstResult = end - start;
                Console.WriteLine("Difference for Enumerable: {0}ms", firstResult.Milliseconds);
    
                GC.Collect();
                Thread.Sleep(2000);
    
                var secondStart = DateTime.Now;
                ArTest();
                var secondEnd = DateTime.Now;
    
                var secondResult = secondEnd - secondStart;
                Console.WriteLine("Difference for loop: {0}ms", secondResult.Milliseconds);
    
                var globalResult = firstResult - secondResult;
                Console.WriteLine("Difference between tests: {0}ms", globalResult.Milliseconds);
    
                Console.ReadKey();
            }
    
            public static void EnTest()
            {
                var stringArray = Enumerable.Range(0, 1000000).Select(i => string.Empty).ToArray();
            }
    
            public static void ArTest()
            {
                var stringArray = new string[1000000];
                for (int i = 0; i < stringArray.Length; i++)
                {
                    stringArray[i] = string.Empty;
                }
            }
