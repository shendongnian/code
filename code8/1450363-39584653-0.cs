    public List<Weeks> GetEnumValues(int input)
    {
        Weeks inputEnum = (Weeks)input;
        var list = new List<Weeks>();
        foreach(var enumItem in Enum.GetValues(typeof(Weeks)).Cast<Weeks>())
        {
            if (inputEnum.HasFlag(enumItem))
            {
                list.Add(enumItem);
            }
        }
        return list;
    }
