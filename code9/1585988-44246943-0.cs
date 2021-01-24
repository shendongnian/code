    public string GetIdByCityName(string name)
    {
        return Cities.ContainsValue(name) ?
            Cities.FirstOrDefault(_ => _.Value == name).Key : String.Empty;
    }
