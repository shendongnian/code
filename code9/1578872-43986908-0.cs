    DataTable dt = (this._dataSet).Tables["Customers"];
    dt.DefaultView.Sort = "Surname";
    dt.TableName = "Customers";
    DataTable defaultviewtable = dt.DefaultView.ToTable();    
    
    // Remove all rows from the table
    for(int i = dt.Rows.Count-1; i >= 0; i--)
    {
        dt.Rows[i].Delete();
    }
    // Add rows back using the sorted view
    for(int i = 0; i < defaultviewtable.Rows.Count; i++)
    {
        dt.Rows.Add(defaultviewtable.Rows[i].ItemArray);
    }
