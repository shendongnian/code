    void test1()
    {
        try { test2(); }
        catch { 
            // some exception-handling such as logging
            return; 
        }
        Debug.WriteLine("Initialization OK");
    }
