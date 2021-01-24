    DataTable dtIdentity = new DataTable();
    reader = ExcelReaderFactory.CreateOpenXmlReader(file.InputStream);
    reader.IsFirstRowAsColumnNames = true;
    dtDetails = reader.AsDataSet().Tables[0];
    DataColumn columnIdentity = new DataColumn("Row");
    columnIdentity.AutoIncrement = true;
    columnIdentity.AutoIncrementSeed = 2;
    columnIdentity.AutoIncrementStep = 1;
    dtIdentity.Columns.Add(columnIdentity);
    dtIdentity.Columns.AddRange(new DataColumn[] { new DataColumn("Domain"), new DataColumn("Username") });
    
    foreach (DataRow dr in dtDetails.Rows) 
    {
        dtIdentity.Rows.Add(null, dr[0], dr[1]);
    }
