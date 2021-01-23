    private Dictionary<Type, Action<MyBaseAbs, MyCustomClass>> _saveOperations = 
                                new Dictionary<Type, Action<MyBaseAbs, MyCustomClass>>();
    //You can then set an entry for each of your derived classes
    _saveOperations[typeof(Mychild1)] = (myObj, myCustomObj) =>
    {
        //Mychild1-specific logic
    };
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
