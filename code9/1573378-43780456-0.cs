    //Instead of this:
    public string Name
    {
        get { return this._name; }
        set { this._name = value; }
    }
    //You can do this:
    public string Name { get; set; }
