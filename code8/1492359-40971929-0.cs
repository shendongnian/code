    var newdt= dt.Clone();
    foreach (DataRow row in dt.Rows)
    {
        var bookNames= row.Field<string>("bookName").Split(',');
        var numOfItems= row.Field<string>("numOfItems").Split(',');
        var categorys= row.Field<string>("category").Split(',');
        //assume all columns having asme number of items seperated by comma 
        for (int i = 0; i < bookNames.Length; i++)
        {
            var newRow = newdt.Rows.Add();
            newRow.SetField("bookName", bookNames[i]);
            newRow.SetField("numOfItems", numOfItems[i]);
            newRow.SetField("category", categorys[i]);
        }
    }
    
    gw1.DataSource = newdt;
    gw1.DataBind();  
