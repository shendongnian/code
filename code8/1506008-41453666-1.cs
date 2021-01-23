    // use an SqlAdapter.Fill to get the below  dataset call
    // sqlAdapter.Fill(ds);
    var ds = new DataSet();
    // this is here so you can test without a database
    // test mocking code
    var recTable = ds.Tables.Add("Record");
    recTable.Columns.Add("Id");
    recTable.Columns.Add("AdministrationName");
    recTable.Columns.Add("ObjectNumber");
    
    var creTable = ds.Tables.Add("Creator");
    creTable.Columns.Add("Id", typeof(int)).AutoIncrement = true;
    creTable.Columns.Add("Text");
    
    var reccreTable = ds.Tables.Add("RecordCreator");
    reccreTable.Columns.Add("RecordId");
    reccreTable.Columns.Add("CreatorId");
    // end mocking code
    
    // copy object graph and build link tables
    foreach(var record in api.RecordList)
    {
        // each main record is created
        var rtRow = recTable.NewRow();
        rtRow["Id"] = record.Id;
        rtRow["AdministrationName"] = record.AdministrationName;
        rtRow["ObjectNumber"] = record.ObjectNumber;
        recTable.Rows.Add(rtRow);
        // handle each collection
        foreach(var creator in record.Creators)
        {
            DataRow creRow; // will hold our Creator row
            // first try to find if the Text is already there
            var foundRows = creTable.Select(String.Format("Text='{0}'", creator.Text));
            if (foundRows.Length < 1) 
            {
                // if not, add it to the Creator table
                creRow =  creTable.NewRow(); // Id is autoincrement!
                creRow["Text"] = creator.Text;
                creTable.Rows.Add(creRow);
            }
            else 
            {
                // otherwise, we found an existing one
                creRow = foundRows[0];
            }
            // link record and creator
            var reccreRow = reccreTable.NewRow();
            reccreRow["RecordId"] = record.Id;
            reccreRow["CreatorId"] = creRow["Id"];
            reccreTable.Rows.Add(reccreRow);
       } 
       // the other collections follow a similar pattern but is left for the reader
    } 
    // now call Update to write the changes to the db.
    // SqlDataAdapter.Update(ds); 
