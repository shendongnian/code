    	List<DataItem>dataitems=new List<DataItem>();
    public MainForm()
		{
			
			InitializeComponent();
			textBox1.TextChanged+=textbox1textChanged;
			getDataItems();
			comboBox1.DisplayMember="Name";
			comboBox1.DataSource=dataitems;
	      
		}
		void textbox1textChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
				comboBox1.DataSource=dataitems.FindAll(d => d.Name.StartsWith(textBox1.Text));
            }
		}
		void getDataItems()
        {
            try
            {
                using (
                    SqlConnection connection =
                        new SqlConnection(ConfigurationManager.ConnectionStrings["DataItem"].ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                        string query = @"SELECT p.ProductId,p.ProductName FROM Product p";
                        var command = new SqlCommand(query, connection) { CommandType = CommandType.Text };
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                        	var data=new DataItem();
                        	data.Id=reader.GetInt32(0);
                        	data.Name=reader.GetString(1);
                        	dataitems.Add(data);
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString(), "Error");
            }
        }
	}
