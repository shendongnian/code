    var keyMap = new Dictionary<char, Func<string, bool>>()
    {
        {'w', MoveUp},
        {'s', MoveDown},
        {'a', s => true}, // using lambda expression
        {
            'd', delegate(string s)
            {
                if (string.IsNullOrWhiteSpace(s) == false)
                {
                    //
                }
                return true;
            }
        } // using anonymous method
    };
    
    // then you can call those like this
    var allow = keyMap['w']("some input");
    if (allow)
    {
        // .... 
    }
    public bool MoveUp(string input)
    {
        return true;
    }
    
    public bool MoveDown(string input)
    {
        return true;
    }
