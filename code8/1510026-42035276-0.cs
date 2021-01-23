    var newObjects = from m in myObjectList
                     select new { m.Id, EnumHere = (int)m.EnumHere };
    var dt = new DataTable();
    using (var reader = ObjectReader.Create(newObjects))
    {
        dt.Load(reader);
    }
