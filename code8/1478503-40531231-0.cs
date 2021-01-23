        bool success = true;
        try
        {
            LuaState.DoFile("main.lua");
        }
        catch (NLua.Exceptions.LuaScriptException e)
        {
            success = false;
            Console.WriteLine(e.ToString());
        }
