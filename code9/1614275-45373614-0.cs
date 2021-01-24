            con.Open();
            string sqlSelectQuery = "Select * FROM LeaveTest";
            SqlCommand cmd = new SqlCommand(sqlSelectQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TimeSpan timespan1;
                timespan1 = dateTimePicker3.Value - dateTimePicker2.Value;
                int totaldays = timespan1.Days;
                textBox2.Text = (dr["finaldays"].ToString());
                int finaldays = Convert.ToInt32(textBox2.Text)+totaldays;
           //textbox2 is a temporary textbox(which is invisible)that is used to put the value finaldays in from the database
                string sql1 = ("Update LeaveTest SET finaldays = '"+ finaldays + "'  WHERE Id='" + comboBox1.Text + "'"); //updating the finaldays in database
                SqlCommand cmd2 = new SqlCommand(sql1, con);
                con.Close();
                con.Open();
              SqlDataReader dr2 =cmd2.ExecuteReader();
                con.Close();
               
                
            }
            con.Close();
