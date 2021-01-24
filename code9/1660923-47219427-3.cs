    namespace ConsoleApp2 {
        class Program {
            static void Main(string[] args) {
                // create class and return its type from script
                // reference current assembly to use interface defined below
                var script = CSharpScript.Create(@"
            public class Test : ConsoleApp2.IRunnable {
                public void Run() {
                    System.Console.WriteLine(""test"");
                }
            }
            return typeof(Test);
            ", ScriptOptions.Default.WithReferences(Assembly.GetExecutingAssembly()));
                script.Compile();
                // run and you get Type object for your fresh type
                var testType = (Type) script.RunAsync().Result.ReturnValue;
                // create and cast to interface
                var runnable = (IRunnable)Activator.CreateInstance(testType);
                // use
                runnable.Run();
                Console.ReadKey();
            }
        }
    
        public interface IRunnable {
            void Run();
        }
    }
