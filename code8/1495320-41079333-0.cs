    class TasksTest
    {
        public void Test()
        {
            List<string> sets = new List<string>
            {
                "set1", "set2", "set3", "set4",
            };
            foreach (var s in sets)
            {
                Console.WriteLine("Set {0}", s);
                var tasks = new[]
                {
                    Task.Factory.StartNew(() => {DoThisFunction1();}, TaskCreationOptions.LongRunning),
                    Task.Factory.StartNew(() => { DoThisFunction2(); }, TaskCreationOptions.LongRunning),
                    Task.Factory.StartNew(() => { DoThisFunction3(); }, TaskCreationOptions.LongRunning),
                };
                Task.WaitAll(tasks);
                Console.WriteLine("End Set {0}\n------------", s);
            }
        }
        void DoThisFunction1()
        {
            Thread.Sleep(1000);
            Console.WriteLine("F1");
        }
        void DoThisFunction2()
        {
            Thread.Sleep(1500);
            Console.WriteLine("F2");
        }
        void DoThisFunction3()
        {
            Thread.Sleep(2000);
            Console.WriteLine("F3");
        }
    }
