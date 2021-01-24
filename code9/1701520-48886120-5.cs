    string Query = "SELECT * FROM YourTable"; 
    DataSet ds;  
    OracleConnection conn;
    OracleDataAdapter da; 
    BindingSource bs;
    DataGridView dgv = new DataGridView();
    
    private void GetDataAndFillDataGridView()
    {
    	conn = new OracleConnection(conn_string);
    	OracleDataAdapter da = new OracleDataAdapter(Query, conn);
    	da.Fill(ds, "Tablename");
    	bs = new BindingSource(ds, "Tablename");
    	dgv.DataSource = bs;
    }
    
    private void buttonSave_Click(object sender, EventArgs e)
    {
    	bs.EndEdit();
    
    	OracleCommandBuilder ocb = new OracleCommandBuilder(da);
    	da.UpdateCommand = ocb.GetUpdateCommand(true);
    	da.InsertCommand = ocb.GetInsertCommand(true);
    	da.DeleteCommand = ocb.GetDeleteCommand(true);
    
    	da.Update(ds, "Tablename");
    }
