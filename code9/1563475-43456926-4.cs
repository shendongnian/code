        static void Main(string[] args)
        {
            Console.WriteLine("Compiling");
            string code = "return () => { System.Threading.Thread.SpinWait(100000000);  System.Console.WriteLine(\" Script end\"); };";
            List<Action> scripts = Enumerable.Range(0, 50).Select(async num =>
                await CSharpScript.EvaluateAsync<Action>(code, ScriptOptions.Default.WithReferences(typeof(Control).Assembly))).Select(t => t.Result).ToList();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            for (int i = 0; i < 10; i++)
                Task.WaitAll(scripts.Select(script => Task.Run(script)).ToArray());
            Func<string, string> dd = (str) => str;
        }
