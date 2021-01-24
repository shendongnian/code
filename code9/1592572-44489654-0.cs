    protected Triangle(string name)
    {
        Name = name;
    }
    public string Name { get; }
    public virtual string GetName()
    {
        return "Shape: " + Name;
    }
