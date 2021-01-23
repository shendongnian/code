    using (DBContext db = new DBContext())
     {
        var val = new StringBuilder();
        IEnumerable<string> results = await db.Database.ExecuteSqlCommandAsync("exec xml_test");
        foreach (var result in results)
          val.Append(result);
        var yourXmlDocument = XDocument.Parse(val);
     }
