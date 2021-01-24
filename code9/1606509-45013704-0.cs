    private void textBox1_TextChanged(object sender, EventArgs e)
        {
         SqlConnection maConnexion = new SqlConnection("Server= localhost; Database= Seica_Takaya;Integrated Security = SSPI; ");
            
            if(textBox1.Text!="")
            {
            maConnexion.Open();
     
            string Var1 = textBox1.Text;
            SqlCommand command = maConnexion.CreateCommand();
            command.Parameters.AddWithValue("@BoardName", Var1 + "%");
            command.Parameters.AddWithValue("@Machine", Var1 + "%");
            command.Parameters.AddWithValue("@SerialNum", Var1 + "%");
            command.Parameters.AddWithValue("@FComponent", Var1 + "%");
            command.CommandText = "SELECT * FROM FailOnly WHERE BoardName LIKE @BoardName OR Machine LIKE @Machine OR SerialNum LIKE @SerialNum OR FComponent LIKE @FComponent AND ReportingOperator != NULL";
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
    maConnexion.Close();
        }
    
        }
