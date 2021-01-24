    private void FillDataSet(HttpPostedFileBase file, DataSet ds)
    {
      using (
        var con =
          new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" File Path";Extended Properties=Excel 12.0;HDR=YES;IMEX=1';"))
      {
          con.Open();
          var dtSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
          var strSheetName = "";
          strSheetName = dtSchema.Rows[0]["TABLE_NAME"].ToString();          
          var cmd = new OleDbCommand();
      var da = new OleDbDataAdapter();
      cmd.Connection = con;
      cmd.CommandType = CommandType.Text;
      cmd.CommandText = "SELECT * FROM [" + strSheetName + "]";
      da = new OleDbDataAdapter(cmd);
      da.Fill(ds);        
      }
    }
