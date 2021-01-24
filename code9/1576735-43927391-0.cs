    var dt = new DataTable();
    using (var reader = XmlReader.Create(filename))
    {
        reader.ReadToFollowing("column");
        do
        {
            dt.Columns.Add(reader.ReadElementContentAsString());
        } while (reader.ReadToNextSibling("column"));
        reader.ReadToFollowing("row");
        do
        {
            var fields = new List<string>();
            reader.ReadToFollowing("field");
            do
            {
                fields.Add(reader.ReadElementContentAsString());
            } while (reader.ReadToNextSibling("field"));
            dt.Rows.Add(fields.ToArray());
        } while (reader.ReadToNextSibling("row"));
    }
