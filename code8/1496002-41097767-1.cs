    var switchCaseAlternative = new Dictionary<string, Action>() 
    {
       {"case1", () => {System.Diagnostic.Debug.WriteLine("One");}},
       {"case2", () => {System.Diagnostic.Debug.WriteLine("Two");}}
    };
