    namespace ConsoleApp3
    {
        class Program
        {
            static async void Main(string[] args)
            {
                var taskA = Task.Run(() => MethodA()); //Start runnning taskA
                var taskB1AndB2 = Task.Run(() => MethodB1()).ContinueWith(async (taskb1) => { await taskb1; await Task.Run(()=>MethodB2()); }).Unwrap(); //When taskB1 is complete, continue with taskB2
                await Task.WhenAll(taskA, taskB1AndB2); //wait until all 3 tasks are completed
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
