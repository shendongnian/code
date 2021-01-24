    namespace ConsoleApp2 {
        class Program {
            static void Main(string[] args) {
    
                var script = CSharpScript.Create(@"
            public class Test : ConsoleApp2.IRunnable {
                public void Run() {
                    System.Console.WriteLine(""test"");
                }
            }
            MyTypes.Add(typeof(Test).Name, typeof(Test));
            ", ScriptOptions.Default.WithReferences(Assembly.GetExecutingAssembly()), globalsType: typeof(ScriptGlobals));
                script.Compile();
                var globals = new ScriptGlobals();
                script.RunAsync(globals).Wait();            
                var runnable = (IRunnable)Activator.CreateInstance(globals.MyTypes["Test"]);
                runnable.Run();
                Console.ReadKey();
            }
        }
    
        public class ScriptGlobals {
            public Dictionary<string, Type> MyTypes { get; } = new Dictionary<string, Type>();
        }
    
        public interface IRunnable {
            void Run();
        }
    }
