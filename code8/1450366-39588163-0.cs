    public List<Weeks> GetEnumValues(int input)
    {
        Weeks inputEnum = (Weeks)input;
        return Enum.GetValues(typeof(Weeks)).Cast<Weeks>().Where(x => inputEnum.HasFlag(x)).ToList();
    }
