    class Program
    {
        static void Main(string[] args)
        {
            //var firstTask = Task.Factory.StartNew(() => MethodB1());
            //var secondTask = firstTask.ContinueWith( (antecedent) => MethodB2());
            for (int i = 0; i < 100; i++)
            {
                Task.WaitAll(MethodA(), MethodB1(MethodB2));
            }
            Console.ReadLine();
        }
        private async static Task MethodA()
        {
            await Task.Run(() => Console.WriteLine("A  at" +  DateTime.Now.TimeOfDay ));
        }
        private async static Task MethodB1(Action callBack)
        {
            await Task.Run(() => Console.WriteLine("B1 at" + DateTime.Now.TimeOfDay));
            callBack?.Invoke();
        }
        private  static void MethodB2()
        {
            Console.WriteLine("B2 at" + DateTime.Now.TimeOfDay);
        }
    }
