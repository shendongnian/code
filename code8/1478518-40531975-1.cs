    myDataSet = new DataSet();
    myDataTable = myDataSet.Tables["myTable"];
    adapter.Fill(myDataTable);
    
    // Update the DB whenever a row changes
    myDataTable.OnRowChanged += (s, e) =>
    {
        adapter.Update(myDataTable);
    }
