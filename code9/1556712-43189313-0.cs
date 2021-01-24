    string _testString {get;set;}
    public string TestString {
        get{
           return _testString;
    
        }
        set{
            try {
                _testString = value;
                _test = int.Parse(_testString);
            }
            catch {    _test = null;}
        }
    }
