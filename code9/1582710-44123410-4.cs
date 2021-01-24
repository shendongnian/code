    static class GlobalVariables
    {
        static private string LockObject = new Object();
        static private string _someVariable;
        static public string SomeVariable 
        { 
            get
            {
                lock(LockObject) { return _someVariable; }
            }
            set
            {
                lock(LockObject) { _someVariable = value; }
            }
        }
    }
