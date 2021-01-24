    class Program {        
        static void Main() {
            var o = new TestObject();
            var test = Console.ReadKey();
            if (test.Key == ConsoleKey.Enter) {
                DoSomething();               
                Console.ReadKey();
                return;
            }
            DoSomethingElse(o);
        }
        static void DoSomething() {
            Console.WriteLine("doing something");
            Thread.Sleep(500);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("GC ran");
        }
        static void DoSomethingElse(TestObject o) {
            Console.WriteLine(o);
        }
    }
    public class TestObject {
        public TestObject() {
            
        }
        ~TestObject() {
            Console.WriteLine("finalizer running");
        }
    }
