    class Program
    {
        static System.Collections.Concurrent.ConcurrentQueue<Action> leftOvers = new System.Collections.Concurrent.ConcurrentQueue<Action>();
        static void Main(string[] args)
        {
        
            for (int i = 0; i < 100; i++)
            {
                Task.WaitAll(MethodA(), MethodB1(MethodB2));
            }
            Action callBack = null;
            while (leftOvers.TryDequeue(out callBack))
            {
                callBack();
            }
            Console.ReadLine();
        }
        private static void QueueMethods(Action method)
        {
            leftOvers.Enqueue(method);
        }
        private async static Task MethodA()
        {
            await Task.Run(() => Console.WriteLine("A  at" +  DateTime.Now.TimeOfDay ));
        }
        private async static Task MethodB1(Action callBack)
        {
            await Task.Run(() => Console.WriteLine("B1 at" + DateTime.Now.TimeOfDay));
            leftOvers.Enqueue(callBack);
        }
        private  static void MethodB2()
        {
            Console.WriteLine("B2 at" + DateTime.Now.TimeOfDay);
        }
    }
