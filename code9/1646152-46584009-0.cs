    // in Person.cs
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
