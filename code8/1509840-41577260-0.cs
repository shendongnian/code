    //CsvReader reader = null;
    DataTable tblCSV = new DataTable("CSV");
    ...
    reader = new CsvReader(new StreamReader(file.Value.FullName), false);
    ...
    tblCSV.Load(reader); 
    foreach(DataRow dr in table.Rows)  
    {
       dr["Sector"] = dr["Sector"].ToString().Replace(" ID", ""); 
    }
    ...
    //sbc.WriteToServer(reader);
    sbc.WriteToServer(tblCSV);
