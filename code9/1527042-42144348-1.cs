    public static SingletonClass Instance
    {
        get
        {
            if (null == _singletonClass)
            {
                lock (_lockObj)
                {
                    if (null == _singletonClass)
                    {
                        _singletonClass = new SingletonClass();
                        _objList = new List<object>();
                    }
                    return _singletonClass;
                }
            }
        }
    }
