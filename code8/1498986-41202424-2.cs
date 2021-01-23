    using (conn = new SqlConnection(SQLConn))
    using (cmd = new SqlCommand(storedprocname, conn)) {
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100);
      cmd.Parameters.Add("d1", SqlDbType.Date, 100);
      cmd.Parameters.Add("d2", SqlDbType.Date, 100);
      cmd.Parameters["@Name"].Value = cboNames.Text.ToString();
      cmd.Parameters["d1"].Value = dtpd1.Value.ToString("MM/dd/yyyy");
      cmd.Parameters["d2"].Value = dtpd2.Value.ToString("MM/dd/yyyy");
      cmd.Parameters.Add("@Dolla", SqlDbType.VarChar, 100);
      cmd.Parameters["@Dolla"].Value = cboDolla.Text.ToString();
    
      //Get a text representation here:
      var text = cmd.PrintCommand();
      //Put a breakpoint here to check the value:
      using (da = new SqlDataAdapter(cmd))
      {
        da.Fill(dt);
      }
    
      int numberOfRecords = 0;
      numberOfRecords = dt.Select().Length;
      MessageBox.Show(numberOfRecords.ToString());
    }
