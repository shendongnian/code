    private bool filled = false;
    public DataSet ds = new DataSet();
    private void bnt_displaylog_Click(object sender, EventArgs e)
    {
        loadDisplayLog();
        database_listbox.Items.Clear();
        foreach (DataRow row in ds.Tables[0].Rows) 
        {
            database_listbox.Items.Add(row["Date"] + "\t\t" + row["Time"] + "\t\t" + row["Action"]); 
        } 
    }
    private void loadDisplayLog(object sender, EventArgs e)
    {
        if( filled ) return;
        try
        {
            string dbconnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Elevator_Database.accdb;";
            string dbcommand = "Select * from Log;";
            OleDbConnection conn = new OleDbConnection(dbconnection);
            OleDbCommand comm = new OleDbCommand(dbcommand, conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
            conn.Open();
            adapter.Fill(ds);
            conn.Close();
        }
        catch (Exception)
        {
            MessageBox.Show("Can not open connection ! ");
            string message = "Error in connection to datasource";
            string caption = "Error";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons); 
        }
        filled = true;
    }
