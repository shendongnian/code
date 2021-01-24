    static Regex _spacer = new Regex(@"\s+");
    public void MyMethod(string someInput)
    {
        ...
        var newString=_spacer.Replace(someInput, " ");
        ...
    }
