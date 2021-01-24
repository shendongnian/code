    // populate DataTable columns
    DataTable dt = new DataTable();
    Collection<Property> properties = entity
        .StaticData.FirstOrDefault()
        .Records.FirstOrDefault()
        .Record.FirstOrDefault()
        .Property;
    // from the collection of xml name attributes in the first record
    dt.Columns.AddRange(properties.Select(p => new DataColumn(p.Name)).ToArray());
    // populate DataTable rows
    Collection<Record> records = entity
        .StaticData.FirstOrDefault()
        .Records.FirstOrDefault()
        .Record;
    // create a row from each record, with the values from the xml value attribute
    foreach (Record r in records)
    {
        dt.Rows.Add(r.Property.Select(p => p.Value).ToArray());
    }
    // bind to the datatable
    dataGridView1.DataSource = dt;
