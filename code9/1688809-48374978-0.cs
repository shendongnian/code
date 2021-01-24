    namespace ConsoleApp5
    {
        public class Program
        {
            public static void Helper(string msg)
            {
                throw new Exception(msg);
            }
            static void Main(string[] args)
            {
                var registerScript = new Engine(c => c
                    .AllowClr(typeof(Program).Assembly)
                    // Allow exceptions from this assembly to surface as JS exceptions only if the message is foo
                    .CatchClrExceptions(ex => ex.Message == "foo")
                )
                .Execute(@"function throwException(){ 
                        try { 
                            var ConsoleApp5 = importNamespace('ConsoleApp5');
                            ConsoleApp5.Program.Helper('foo'); 
                            // ConsoleApp5.Program.Helper('goo'); // This will fail when calling execute becase the predicate returns false 
                            return ''; 
                        }  
                        catch(e) { 
                            return e; 
                        } 
                };
                var f = throwException();")
                .GetValue("f");
            }
        }
    }
