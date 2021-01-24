    var sourceDataSet = new DataSet();
    var sourceTable = new DataTable("TableWithBinary");
    sourceDataSet.Tables.Add(sourceTable);
    sourceTable.Columns.Add("Id");
    sourceTable.Columns.Add("File", typeof(byte[]));
    sourceTable.Rows.Add(1, new byte[] { 1, 0, 2 });
    sourceTable.Rows.Add(2, new byte[] { 1, 3, 2 });
    // write option 1
    string schema = sourceDataSet.GetXmlSchema();
    string getxml = sourceDataSet.GetXml();
    // write option 2
    var writexmlstream = new StringWriter();
    sourceDataSet.WriteXml(writexmlstream, XmlWriteMode.WriteSchema);
    string writexmlWithSchema = writexmlstream.ToString();
    // read wrong (missing schema)
    var targetCorrupted = new DataSet();
    targetCorrupted.ReadXml(new StringReader(getxml));
    // read correct with schema in every xml file
    var targetFromXmlWithSchema = new DataSet();
    targetFromXmlWithSchema.ReadXml(new StringReader(writexmlWithSchema));
    // read correct with separate schema definition and data
    var targetFromXml = new DataSet();
    targetFromXml.ReadXmlSchema(new StringReader(schema));
    targetFromXml.ReadXml(new StringReader(getxml));
