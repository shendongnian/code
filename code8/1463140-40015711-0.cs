    class Program
    {
        static void Main(string[] args)
        {
            CSharpReplAsync().Wait();
        }
        private static async Task CSharpReplAsync()
        {
            Console.WriteLine("C# Math REPL");
            Console.WriteLine("You can use any method from System.Math");
            var options = ScriptOptions.Default
                .AddImports("System", "System.Console", "System.Math");
            var state = await CSharpScript.RunAsync("WriteLine(\"Hello from Roslyn\")", options);
            while (true)
            {
                Console.Write("> ");
                string expression = Console.ReadLine();
                if (string.IsNullOrEmpty(expression))
                    break;
                try
                {
                    state = await state.ContinueWithAsync(expression, options);
                    if (state.ReturnValue != null)
                        Console.WriteLine(state.ReturnValue);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
