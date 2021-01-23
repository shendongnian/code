    protected static Author LoadFromReader(IDataRecord row)
    {
        Author a = null;
        if (row != null)
        {
            a = new Author
            {
                AuthFirstName = row.GetString(row.GetOrdinal("authName")),
                AuthLastName = row.GetString(row.GetOrdinal("authLName")),
                Country = new Country
                {
                   CountryId = row.GetInt32(row.GetOrdinal("countryID"))
                },
            };
        }
        return a;
    }
