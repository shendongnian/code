    public Method1(string a, string b) : this(a, b, "", "")
    {
    }
    public static Method1 CreateMethodWithEndParams(string c, string d)
    {
        Method1 method = new Method1("", "", c, d);
        return method;
    }
    public Method1(string a, string b, string c, string d)
    {
    }
