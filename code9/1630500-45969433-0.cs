    private static MyClass _myClass;
    private static object _lock = new object();
    public static MyClass GetMyClass()
    {
        if (_myClass == null)
        {
            lock(_lock)
            {
                if (_myClass == null)
                {
                    _myClass = new MyClass();
                }
            }
        }
        return _myClass;
    }
