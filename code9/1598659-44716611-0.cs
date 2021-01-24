    private void button1_Click(object sender, EventArgs e)
    {
    string txtbx9 = textBox9.Text.ToString();
    string cmbbx2 = comboBox2.SelectedItem.ToString();
    string name = textBox1.Text.ToString();
    string surname = textBox2.Text.ToString();
    string company = textBox3.Text.ToString();
    string txtbx8 = textBox8.Text.ToString();
    string sts = "In House";
    
        try
        {
            connection.Open();
    
    
            MessageBox.Show("Payment approved.");
            richTextBox1.Text = richTextBox1.Text + "The hotel received " + txtbx9 + " from this guest";
                string rtb = richTextBox1.Text.ToString();
    
            OleDbCommand command = new OleDbCommand();
    
            command.Connection = connection;
            command.CommandText = "INSERT INTO billing(g_name,g_surname,g_company,g_totalrate, g_paid, g_typepaid, info, u_add, u_tadd, g_ad, g_dd, g_amountofdays) VALUES('" + name + "','" + surname + "','" + company + "','" + txtbx8 + "', '" + txtbx9 + "', '" + cmbbx2 + "', '" + rtb + "', '" + label12.Text.ToString() + "', '" + this.dateTimePicker1.Value +"','"+textBox4.Text.ToString()+"','"+textBox5.Text.ToString()+"','"+textBox6.Text.ToString()+"')"; ;
            command.ExecuteNonQuery();
    
            command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE guestreg SET g_paidstatus='Paid '"+txtbx9+"'' where g_name ='"+name+"' and g_status = '"+sts"'";
    
            command.ExecuteNonQuery();
    
    }
    }
