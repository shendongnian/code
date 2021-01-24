    var engine = new Engine(c => c
        .DebugMode()
        .AllowClr(typeof(Program).Assembly)
    );
            
    engine.Step += Engine_Step;
    try
    {
        var r = engine
        .Execute(@"function throwException(){ 
            // undefined.test(); // This will cause a runtime exception
            // fun ction test () { } // This will cause a parser exception
            try { 
                throw 'Handled exception'; // No notification on this exception it is handled in JS
                return ''; 
            }  
            catch(e) { 
                return e; 
            } 
    };
    var f = throwException();")
        .GetValue("f");
    }
    catch (ParserException pEx)
    {
        Console.WriteLine("Parser Exception " + pEx.Message);
    }
    catch (JavaScriptException rEx)
    {
        Console.WriteLine("Runtime Exception " + rEx.Message);
    }
