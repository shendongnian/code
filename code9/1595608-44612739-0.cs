    ScriptRuntime runtime = Python.CreateRuntime();
    runtime.LoadAssembly(Assembly.GetAssembly(typeof(MyNameSpace.MyClass)));
    ScriptEngine eng = runtime.GetEngine("py");
    ScriptScope scope = eng.CreateScope();
    ScriptSource src = eng.CreateScriptSourceFromString(MySource, SourceCodeKind.Statements);
    var result = src.Execute(scope);
