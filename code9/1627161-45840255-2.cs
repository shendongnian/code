    public static NameClass FillIt(this NameClass c, string name)
    {
        if (c == null)
            c = new NameClass();
        if (string.IsNullOrEmpty(name) == false)
            c.IsValid = true;
        c.Name = name;
        //note: return the object c
        return c;
    }
