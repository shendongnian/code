    public Repair()
    {
    	InitializeComponent();
    
    	SqlConnection maConnexion = new SqlConnection("Server= localhost; Database= Seica_Takaya;Integrated Security = SSPI; ");
    	maConnexion.Open();
    	SqlCommand command = maConnexion.CreateCommand();
    
    	if (Program.UserType == "admin")
    	{
    		command.CommandText = "SELECT * FROM FailOnly";
    	}
    	else
    	{
    		command.CommandText = "SELECT * FROM FailOnly WHERE ReportingOperator IS NULL";
    	}
    
    	SqlDataAdapter sda = new SqlDataAdapter(command);
    	DataTable dt = new DataTable();
    	sda.Fill(dt);
    	DataColumn dcIsDirty = new DataColumn("IsDirty", typeof(bool));
    	dcIsDirty.DefaultValue = false;
    	dt.Columns.Add(dcIsDirty);
    	dataGridView1.DataSource = dt;
    	maConnexion.Close();
        dataGridView1.Columns[19].DefaultCellStyle.NullValue = false;
    }
