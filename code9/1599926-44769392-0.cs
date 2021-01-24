    Public Dictionary<int,string> GetProductsDict(DataTable dt)
    {
        return dt.AsEnumerable()
          .ToDictionary<DataRow, int, string>(x => x.Field<int>(0),
                                    x => x.Field<string>(1));
    }
