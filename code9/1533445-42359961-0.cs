    System.Data.DataTable dt = new System.Data.DataTable();
    dt.Columns.Add("col_1");
    dt.Columns.Add("col_2");
    dt.Columns.Add("col_3");
          
     doc.Descendants("product")
                .ToList()
                .ForEach(
                    n => dt.Rows.Add(n.Attribute("name").Value,
                                     n.Attribute("prodid").Value, 
                                     n.Attribute("price").Value));
