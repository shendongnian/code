    private void button3_Click(object sender, EventArgs e)
    {
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }  
        string student = "Select * From tbl_student";
    
        OleDbCommand loadstudent = new OleDbCommand(student, cn);
        loadstudent.Parameters.AddWithValue("@SId", textBox8.Text + "%");
    
        rd = loadstudent.ExecuteReader();
     
        if (rd.HasRows == true)
        {
            // ipapalabas ung labas
            while (rd.Read())
            {
    
            messageBox.Show("Oops sobra tama na ");
    
            }
        }
        else
        {
            MessageBox.Show("No record(s) found.");
        }
        cn.Close();
    
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        string s = "Select * From Borrow";
    
        OleDbCommand sa = new OleDbCommand(s, cn);
        loadstudent.Parameters.AddWithValue("@SId", textBox8.Text + "%");
    
        rd = sa.ExecuteReader();
     
        while(rd.Read()) // You need to read first to get your data.
        {
            if (Convert.ToInt32(rd["B_Quan"].ToString()) > 3)
            {
                MessageBox.Show("Oops sobra tama na ");
            }
        }
        cn.Close();
    
        if (cn.State == ConnectionState.Closed) cn.Open();
     
        cmd = new OleDbCommand("Select * From Borrow", cn);
        rd = cmd.ExecuteReader();// ipapalitaw
        if (rd.HasRows == true)
        {
            // ipapalabas ung labas
            while (rd.Read())
            {
                if (Convert.ToInt32(rd["B_Quan"].ToString()) > 3)
    
                {
                    MessageBox.Show("Oops sobra tama na ");
                    return;
    
                }
            }
        }
    }
