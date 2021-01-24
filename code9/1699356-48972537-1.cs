    using System;
    using Jint;
    using Jint.Native;
    
    namespace JintSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                var engine = new Engine();
                JsValue require(string fileName)
                {
                    string jsSource = System.IO.File.ReadAllText(fileName);
                    var res = engine.Execute(jsSource).GetCompletionValue();
                    return res;
                }
    
                engine.SetValue("require", new Func<string, JsValue>(require))
                .SetValue("log", new Action<string>(System.Console.WriteLine));
    
                JsValue name = engine.Execute(@"require('C:\\file1.js')").GetCompletionValue();
            }
        }
    }
