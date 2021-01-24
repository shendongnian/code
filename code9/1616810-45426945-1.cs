    //If DataSet contains the table already, remove it first
    if (ds.Tables.Contains(tbl)) 
          ds.Tables.Remove(tbl);
    //Open connection here. Better with using
      cmd.CommandText = "YOUR_SQL_QUERY_GOES_HERE";
      adp.SelectCommand = cmd;
      adp.Fill(ds, tbl);
    //close the connection here
    rw = ds.Tables[tbl].NewRow();        //Add a new row
    rw[0] = "-1";                        //Set it's value
    rw[1] = "Itemtext";                  //Set it's text
    ds.Tables[tbl].Rows.InsertAt(rw, 0); //Insert this row in the DataTable(DT) at Index 0
    comboBox1.DataSource = ds.Tables[tbl]; //Assign the DT in the DataSource of the combobox
    comboBox1.DataTextField = "Default Text";
    comboBox1.DataValueField = "Default Value";
    comboBox1.DataBind();
    
