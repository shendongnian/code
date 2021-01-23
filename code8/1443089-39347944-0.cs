     static private DataTable ResultsData = new DataTable();
     ResultsData = obserableCollectionName().ToDataTable();
     System.IO.StringWriter writer = new System.IO.StringWriter();
     ResultsData.WriteXml(writer, XmlWriteMode.WriteSchema, false);
     string result = writer.ToString();
   
