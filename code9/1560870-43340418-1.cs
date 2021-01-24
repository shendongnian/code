    IEnumerable<EnumValues> clientValues = 
        from Client c in Enum.GetValues(typeof(Client))
        select new EnumValues
        {
            ID = (int)c,
            Name = c.ToString()
        };
