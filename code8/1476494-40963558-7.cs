    public LuaTable getNewTableCSharp()
    {
        using (var x = lua.GetFunction("getNewTableLua")) {
            // Still leaks, but you can't do anything about it.
            return (LuaTable)x.Call()[0];
        }
    }
