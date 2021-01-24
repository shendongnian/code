     public Repair()
        {
            InitializeComponent();       
    
            SqlConnection maConnexion = new SqlConnection("Server= localhost; Database= Seica_Takaya;Integrated Security = SSPI; ");
            maConnexion.Open();
            SqlCommand command = maConnexion.CreateCommand();
            if (Program.UserType == "admin")
            {
            
                command.CommandText = "SELECT * FROM FailOnly.";
                
            }
            else
            {
    
                command.CommandText = "SELECT * FROM FailOnly WHERE ReportingOperator != NULL";
    
    
            }
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            maConnexion.Close();
    
        }
