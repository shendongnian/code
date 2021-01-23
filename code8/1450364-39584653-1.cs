    public List<Weeks> GetEnumValues(int input)
    {
        Weeks inputEnum = (Weeks)input;
        var list = new List<Weeks>();
        foreach(var enumFlag in Enum.GetValues(typeof(Weeks)).Cast<Weeks>())
        {
            if (inputEnum.HasFlag(enumFlag))
            {
                list.Add(enumFlag);
            }
        }
        return list;
    }
