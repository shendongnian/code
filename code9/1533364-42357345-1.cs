    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using IronPython.Hosting;
    using Microsoft.Scripting;
    using Microsoft.Scripting.Hosting;
    using IronPython.Runtime;
    static void Main(string[] args)
            {
                ScriptRuntimeSetup setup = Python.CreateRuntimeSetup(null);
                ScriptRuntime runtime = new ScriptRuntime(setup);
                ScriptEngine engine = Python.GetEngine(runtime);
                ScriptSource source = engine.CreateScriptSourceFromFile("GuessingGameOne.py");
                ScriptScope scope = engine.CreateScope();
                // You don't need this section, but added in case
                // you decide to use it later.
                List<String> argv = new List<String>();
                //Do some stuff and fill argv
                argv.Add("foo");
                argv.Add("bar");
                engine.GetSysModule().SetVariable("argv", argv);
                // You will need this though....
                source.Execute(scope);
            }
