    public Dictionary<Type, Action<MyBaseAbs, MyCustomClass>> _saveOperations;
    public MyCustomClass SaveOperation(MyBaseAbs obj)
    {
        //do the common saving operations here 
        var result = new MyCustomClass();
        //....
        var actualType = obj.GetType();
        if(_saveOperations.ContainsKey(actualType))
        {
            _saveOperations[actualType](obj, result);
        }
        return result;
    }
