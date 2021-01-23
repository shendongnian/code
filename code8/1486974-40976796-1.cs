    var table = new DataTable();
    table.Columns.Add("id", typeof(int));
    table.Columns.Add("name", typeof(string));
    table.Columns.Add("description", typeof(string));
    table.Rows.Add(1, "first", "The first row");
    table.Rows.Add(2, "second", "The second row");
    // Serialize
    var serializer = new SerializerBuilder()
        .WithTypeConverter(new DataTableTypeConverter())
        .Build();
    var yaml = serializer.Serialize(table);
    // Deserialize
    var deserializer = new DeserializerBuilder()
        .WithTypeConverter(new DataTableTypeConverter())
        .Build();
    var parsedTable = deserializer.Deserialize<DataTable>(yaml);
