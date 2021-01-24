    using System;
    using System.Threading;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            RunTest();
            RunTest();
        }
    
        private static void RunTest()
        {
            //WeakReference wfRaiser;
            //WeakReference wfSubscriber;
    
            var before = GC.GetTotalMemory(true);
    
            //region 1: scope of raiser
            {
                var raiser = new Raiser();
                //wfRaiser = new WeakReference(raiser);
                //region 2: scope of subscriber
                {
                    var subscriber = new Subscriber();
                    //wfSubscriber = new WeakReference(subscriber);
                    raiser.ValueChanged += subscriber.HandlingMethod;
                }
    
                raiser.SetValue(153);
            }
    
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
    
            var after = GC.GetTotalMemory(true);
    
            Console.WriteLine(//$"Is raiser alive? {wfRaiser.IsAlive}\n" +
                              //$"Is subscriber alive? {wfSubscriber.IsAlive}\n" +
                              "Memory size (bytes):\n" +
                              $"- before : {before} \n" +
                              $"- after : {after}\n" +
                              $"=> Leak: {after - before}");
        }
    }
    
    public class Raiser
    {
        public event EventHandler<int> ValueChanged;
        public void SetValue(int value) => ValueChanged?.Invoke(this, value);
    }
    
    public class Subscriber
    {
        private readonly double[] MyData = new double[9999];
        public void HandlingMethod(object sender, int value) => Console.WriteLine($"Value changed: {value}");
    }
