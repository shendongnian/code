    DataClass FromString(string input)
    {
        return new DataClass{
            Property1 = r.Substring(0,2),
            Property2 = r.Substring(3,5),
            Property3 = r.Substring(9,10)
        }
    }
