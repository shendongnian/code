    using (var reader = new XmlTextReader(@"your url"))
    {
        // note this
        reader.EntityHandling = EntityHandling.ExpandCharEntities;
        while (reader.Read())
        {
            // here it will be EntityReference with no exceptions
        }
    }
