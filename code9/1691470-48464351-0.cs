     private void button1_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
    
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into cloggingInfo(Date, PID, Operator, Type)values('"+labelTime.Text+"', '" + cboStatePid.SelectedItem+ "', '" + cboStateOperator.SelectedItem+ "', '" + cboStateType.SelectedItem+ "')";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                MessageBox.Show("Start added succesfully");
                listView1.Items.Clear();
                AddToListView();
            }
        }
