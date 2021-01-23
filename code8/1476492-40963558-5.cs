    public void testMemTable()
    {
        m_lua.NewTable("tabx");
        using (LuaTable tabx = m_lua.GetTable("tabx")) {
            for (int i = 0; i < 20000; i++) {
                tabx[i] = i * 10;
            }
        }
    }
