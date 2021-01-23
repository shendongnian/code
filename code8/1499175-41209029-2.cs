    da.Fill(table);
    if(table.Rows.Count == 0)
    {
      MessageBox.Show("No Records with given ID ...");
      return;
    }
    //Rows present and thus do processing
