    ScriptEngine engine = Python.CreateEngine();
    ScriptScope scope = engine.CreateScope();
    engine.ExecuteFile(@"C:\path\hello.py", scope);
    var result = scope.GetVariable("a");
    Console.WriteLine(result);
    Console.ReadLine();
