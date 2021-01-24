    DataTable dtTest = new DataTable();
    dtTest.Columns.Add("Name");
    dtTest.Columns.Add("NickName");
    dtTest.Columns.Add("Code");
    dtTest.Columns.Add("reference");
    
    dtTest.Rows.Add("Yash", "POPs", "Vapi", "None1");
    dtTest.Rows.Add("shilpa", "shilpa", "valsad", "None2");
    dtTest.Rows.Add("Dinesh", "dinu", "pune", "None3");
    dtTest.Rows.Add("rahul", "mady", "pardi", "None4");
    
    dtTest.AsEnumerable().ToList().ForEach(x => CreateXml(x));
    
    public void CreateXml(DataRow row)
    {
      XDocument xmlDoc = new XDocument(
          new XElement(
              "File",
               new XElement(
                   "company_details",
                   new XElement(
                       "company",
                   new XElement(
                       "Name",
                        row.Field<string>("Name")),
                   new XElement(
                       "NickName",
                        row.Field<string>("NickName"))),
                   new XElement(
                        "Details",
                   new XElement(
                        "reference",
                         row.Field<string>("reference"))))));
      xmlDoc.Save(Server.MapPath(row.Field<string>("Name")) + ".xml");
    }
