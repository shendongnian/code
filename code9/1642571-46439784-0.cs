    // syntactic sugar for:
    public string Name { get { return "bob"; } }
    // results into:
    public string get_Name() 
    {
        return "bob";
    }
