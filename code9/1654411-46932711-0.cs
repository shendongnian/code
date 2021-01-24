    using IronPython.Hosting;
    using Microsoft.Scripting.Hosting;
    static void RunPythonScript()
    {
        var engine = Python.CreateEngine();
        dynamic scope = engine.CreateScope();
        engine.ExecuteFile("greeting.py", scope);
        var greeting = scope.greet("John");
        Console.WriteLine(greeting);
    }
