    class TestServer 
    {
        string x = "";
        string y = "";
        string z = "";
    
        TestServer SetX(string val)
        {
            x = val;
            return this;
        }
        TestServer SetY(string val)
        {
            y = val;
            return this;
        }
        TestServer SetZ(string val)
        {
            z = val;
            return this;
        }
    }
