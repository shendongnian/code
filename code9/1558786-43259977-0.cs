    class Program {
        static void Main(string[] args) {
            var c1 = new Class1();
            c1.DoSomething();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.ReadKey();
        }        
    }
    public class Class1
    {
        public void DoSomething()
        {
        }
        private volatile int _i = 100;
        private volatile int _j = 100;
        ~Class1()
        {
            Console.WriteLine("shutdown:" + Environment.HasShutdownStarted);
            Task.Run(() => _j *= 2); //Does not progress _j
            //_i *= 2; //Progress _i from 100 to 200            
            Thread.Sleep(1000);
            Console.WriteLine("In destructor. _i = " + _i);
            Console.WriteLine("In destructor. _j =  " + _j);
        }
    }
