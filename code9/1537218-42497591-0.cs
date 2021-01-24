    void Main()
    {
    	DataTable YourResultSet = new DataTable();
    	string path = @"D:\Sample\Database\client.dbf";
    
    	using (OleDbConnection connection =
    	new OleDbConnection("Provider=VFPOLEDB;Data Source=" + Path.GetDirectoryName(path)))
    	using (OleDbCommand command = new OleDbCommand(
    	string.Format("select id from {0}", Path.GetFileNameWithoutExtension(path)), connection))
    	{
    	connection.Open();
    	YourResultSet.Load(command.ExecuteReader());
    	connection.Close();
    	}
    	
    	Form f = new Form();
    	DataGridView dgv = new DataGridView { Dock = DockStyle.Fill, DataSource=YourResultSet};
    	f.Controls.Add(dgv);
    	f.Show();
    }
