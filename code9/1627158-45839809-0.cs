    public static void FillIt(this NameClass c, string name)
    {
        if (string.IsNullOrEmpty(name) == false)
        {
            c.IsValid = true;
        }
        c.Name = name;
    }
