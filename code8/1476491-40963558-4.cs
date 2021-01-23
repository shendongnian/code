    public LuaTable testMemTable()
    {
       // This code does nothing.  You get a new reference to the Lua table
       // object, and then you immediately dispose it.  You can remove this
       // whole chunk of code; it's a really expensive no-op.
       LuaTable tabx = m_lua.GetTable("tabx");
       if (tabx != null)
       {
          tabx.Dispose();
          tabx = null;
          GC.Collect();
          GC.WaitForPendingFinalizers();
       }
       m_lua.NewTable("tabx");
       // You create a new CLR object referencing the new Lua table, but you
       // don't dispose this CLR object.
       tabx = m_lua.GetTable("tabx");
       for (int i = 0; i < 20000; i++)
          tabx[i] = i * 10;
       return  tabx;
    }
