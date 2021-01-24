     public static void Test()
            {
                var list = new List<int>();
                for (int i = 0; i < 10000; i++)
                {
                    list.Add(i);
                }
    
                GetBool1(list);
                GetBool2(list);
                GetBool3(list);
                Console.ReadLine();
            }
    
            private static void GetBool1(List<int> list)
            {
                System.Diagnostics.Stopwatch watcher = new System.Diagnostics.Stopwatch();
    
                watcher.Start();
                foreach (var item in list.Where(PrintAndEvaluate))
                {
                    Thread.Sleep(1);
                }
                watcher.Stop();
                Console.WriteLine("GetBool1 - {0}", watcher.ElapsedMilliseconds);
            }
    
            private static bool PrintAndEvaluate(int x)
            {
                return x % 2 == 0;
            }
    
            private static void GetBool2(List<int> list)
            {
                System.Diagnostics.Stopwatch watcher = new System.Diagnostics.Stopwatch();
    
                watcher.Start();
                foreach (var item in list.Where(PrintAndEvaluate).ToList())
                {
                    Thread.Sleep(1);
                }
                watcher.Stop();
                Console.WriteLine("GetBool2 - {0}", watcher.ElapsedMilliseconds);
            }
