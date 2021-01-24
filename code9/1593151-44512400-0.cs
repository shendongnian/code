    private void btn_add_Click(object sender, EventArgs e)
    {
       if (textBox_tarikh.Text == "" || textBox_resit.Text == ""||textBox_bayaran.Text == "")
            {
                MessageBox.Show("Please Fill In The Blank");
            }
       string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\acap\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30";
       SqlConnection connection = new SqlConnection(connectionString);
       SqlCommand cmd ;
       try
        {
          if(connection.State == ConnectionState.Closed) connection.Open();
          cmd = new SqlCommand("INSERT Pembayaran (Description, Date, No_Resit, Payment, Studentic) VALUES (@Description, @date, @resit, @payment, @val)", connection);
          cmd.Parameters.AddWithValue("@val", bResult);
          cmd.Parameters.AddWithValue("@Description", label4.Text);
          cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(textBox_tarikh.Text));
          cmd.Parameters.AddWithValue("@resit", textBox_resit.Text);
          cmd.Parameters.AddWithValue("@payment", textBox_bayaran.Text);
          cmd.Executenonquery();
          
          SqlDataAdapter da = new SqlDataAdapter("Select * from Pembayaran",connection);
          DataTable dt = new DataTable();
          da.Fill(dt);
          GridView.DataSource = dt;
        }
       catch(Exception ex)
       {
       }
       finally
       {
          if(connection.State == ConnectionState.Opened) connection.Close();
       }
    }
