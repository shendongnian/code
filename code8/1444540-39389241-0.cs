    private void Ok_button3_Click(object sender, EventArgs e)
    {
    OleDbConnection con = new OleDbConnection(@"Provider =        Microsoft.ACE.OLEDB.12.0; Data Source = E:\database.accdb; Persist Security Info =False;");
    OleDbCommand cmd = new OleDbCommand(String.Concat("Select * From ",comboBox1.Text), con); 
    cmd.CommandType = CommandType.Text;
    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
    DataTable dt = new DataTable();            
    da.Fill(dt);
    dt.TableName = "Project";
    dataGridView1.DataSource = dt;
    }
