    private void FillInDataGrid(string SQLstring)
    {
        string cn = ConfigurationManager.ConnectionStrings["Scratchpad"].ConnectionString; //hier wordt de databasestring opgehaald
        DataSet ds = new DataSet();
        // dispose objects that implement IDisposable
        using(SqlConnection myConnection = new SqlConnection(cn))
        {
            SqlDataAdapter dataadapter = new SqlDataAdapter(SQLstring, myConnection);
            
            // set the CommandTimeout
            dataadapter.SelectCommand.CommandTimeout = 60;  // seconds
            
            myConnection.Open();
            dataadapter.Fill(ds, "Authors_table"); 
        }
        dataGridView1.DataSource = ds;
        dataGridView1.DataMember = "Authors_table";
    }
