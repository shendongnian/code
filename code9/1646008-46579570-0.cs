    namespace ConsoleApp3
    {
        class Program
        {
            static async void Main(string[] args)
            {
                var taskA = Task.Run(() => MethodA());
                var taskB1AndB2 = Task.Run(() => MethodB1()).ContinueWith(async (taskb1) => { await taskb1; await Task.Run(()=>MethodB2()); }).Unwrap();
                await Task.WhenAll(taskA, taskB1AndB2);
            }
    
            private static void MethodA()
            {
                Console.WriteLine("A");
                // more code is running here (30 min)
            }
    
            private static void MethodB1()
            {
                Console.WriteLine("B1");
                // more code is running here (2 min)
            }
    
            private static void MethodB2()
            {
                Console.WriteLine("B2");
            }
        }
    }
