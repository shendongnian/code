    static class GlobalVariables
    {
        static private string LockObject = new Object();
        static public string SomeVariable 
        { 
            private string _someVariable;
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
