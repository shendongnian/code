    dbConn = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source=" + dialog.FileName + "; Persist Security Info = False; Jet OLEDB:Database Password = " + textBoxPwdComet.Text + "; Mode = Share Deny None");
     SqlConnection conn2 = db.apriconnessione();
     string query = "SELECT CODMARCA,CODART,DESCR,UM,PRZNETTO,PRZCASA,DATAAGG FROM ARTICOLI"; 
    OleDbDataAdapter da = new OleDbDataAdapter(query,dbConn);
    DataTable dt = new DataTable();
    da.Fill(dt);
    conn2.Open();
    SqlBulkCopy bulk = new SqlBulkCopy(conn2);
    bulk.DestinationTableName = "ARTICOLI";
    bulk.WriteToServer(dt);
    conn2.close();
    
