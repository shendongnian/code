    private SqlConnection _conn = null;
    public MyClass()
    {
         _conn = new SqlConnection();
    }
    public void f3()
    {
        var c = _conn;
        // 150 lines of stuff
        //  OK, I guess we're done with it now!
        c.Dispose();
        c = null;
        //  Now _conn is not null, yet the next call to f3() will find it unexpectedly 
        //  in an invalid state. You really don't want that. 
    }
