        static void Main(string[] args)
        {
            Console.WriteLine("Compiling");
            string code = "System.Threading.Thread.SpinWait(100000000);  System.Console.WriteLine(\" Script end\");";
            List<Script<object>> scripts = Enumerable.Range(0, 50).Select(num =>
                 CSharpScript.Create(code, ScriptOptions.Default.WithReferences(typeof(Control).Assembly))).ToList();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced); // for fair-play
            for (int i = 0; i < 10; i++)
                Task.WaitAll(scripts.Select(script => script.RunAsync()).ToArray());
        }
