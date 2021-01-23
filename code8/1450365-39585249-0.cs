    public List<Weeks> GetEnumValues(int input)
    {
        return ((Weeks)input)
             .ToString()
             .Split(',')
             .Select(day => Enum.Parse(typeof(Weeks), day))
             .ToList();
    }
