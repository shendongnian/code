    foreach(DataRow row in dt.Rows)
    {
        IDictionary<string,object> contact = new ExpandoObject();
        foreach(string colName in columns)
        {
            contact.Add(colName,row[colName]);
        }
        dynamic contactDynamic = contact as ExpandoObject;
        Console.WriteLine(contact.Phone);
    }
