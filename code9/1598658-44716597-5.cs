    try
    {
          connection.Open();   
    
          MessageBox.Show("Payment approved.");
          richTextBox1.Text = richTextBox1.Text + "The hotel received " + txtbx9 + " from this guest";
          string rtb = richTextBox1.Text.ToString();
          command.Connection = connection;
          command.CommandText = "INSERT INTO billing(g_name,g_surname,g_company,g_totalrate, g_paid, g_typepaid, info, u_add, u_tadd, g_ad, g_dd, g_amountofdays) VALUES(@name,@surname,@company,@txtbx8,@txtbx9,@cmbbx2,@rtb,@label12Text,@dateTimePicker1Value,@textBox4Text,@textBox5Text,@textBox6Text')";
		  command.Parameters.Add(new SqlParameter("@name",name));
		  command.Parameters.Add(new SqlParameter("@surname",surname));
		  command.Parameters.Add(new SqlParameter("@company",company));
		  command.Parameters.Add(new SqlParameter("@txtbx8",txtbx8));
		  command.Parameters.Add(new SqlParameter("@txtbx9",txtbx9));
		  command.Parameters.Add(new SqlParameter("@cmbbx2",cmbbx2));
		  command.Parameters.Add(new SqlParameter("@rtb",rtb));
		  command.Parameters.Add(new SqlParameter("@label12Text",label12.Text.ToString()));
		  command.Parameters.Add(new SqlParameter("@dateTimePicker1Value",this.dateTimePicker1.Value.ToString()));
		  command.Parameters.Add(new SqlParameter("@textBox4Text",textBox4.Text.ToString()));
		  command.Parameters.Add(new SqlParameter("@textBox5Text",textBox5.Text.ToString()));
		  command.Parameters.Add(new SqlParameter("@textBox6Text",textBox6.Text.ToString()));
          command.ExecuteNonQuery();
          command.CommandText = "UPDATE guestreg SET g_paidstatus=@paidStatus where g_name =@name and g_status = @status";
		  command.Parameters.Add(new SqlParameter("@paidStatus","Paid " + txtbx9));
		  command.Parameters.Add(new SqlParameter("@name",name));
		  command.Parameters.Add(new SqlParameter("@status",sts));
          command.ExecuteNonQuery();
    }
