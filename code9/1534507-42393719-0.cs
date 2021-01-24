     public static void ReadXMLResponse()
        {
            XDocument doc = XDocument.Load(@"D:\\Response.xml");
            DataSet ds = new DataSet();
      
            System.Data.DataTable dt = new System.Data.DataTable("INTREV2012");
            dt.Columns.Add("col1");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Month");
            dt.Columns.Add("Year");
            dt = doc.Descendants("INTREV2012").Descendants("Transaction")
                      .Select(x =>
                      {
                          var row = dt.NewRow();
                          row.SetField<string>("col1", (string)x.Element("TransactionType").Value);
                          row.SetField<string>("Amount", (string)x.Element("Amount").Value);
                          row.SetField<string>("Month", (string)x.Element("Month").Value);
                          row.SetField<string>("Year", (string)x.Element("Year").Value);
                          return row;
                      }).CopyToDataTable();
            ds.Tables.Add(dt);
            dt = new System.Data.DataTable("PMTREV2012");
            dt.Columns.Add("col1");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Month");
            dt.Columns.Add("Year");
            dt = doc.Descendants("PMTREV2012").Descendants("Transaction")
                      .Select(x =>
                      {
                          var row = dt.NewRow();
                          row.SetField<string>("col1", (string)x.Element("Title").Value);
                          row.SetField<string>("Amount", (string)x.Element("Amount").Value);
                          row.SetField<string>("Month", (string)x.Element("Month").Value);
                          row.SetField<string>("Year", (string)x.Element("Year").Value);
                          return row;
                      }).CopyToDataTable();
            ds.Tables.Add(dt);
            
            Console.WriteLine(ds.Tables.Count);
        }
