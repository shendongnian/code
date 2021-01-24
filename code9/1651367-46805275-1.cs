    DataTable dtclubroom = new DataTable();
	private void button4_Click(object sender, EventArgs e)
    {
        employee();
    }
    public void employee()
    {
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter(command.CommandText, myConnection);
        try
        {
            myConnection.Open();
            dtclubroom.Clear();
            command.Connection = myConnection;
            command.CommandText = "Select * from employee ";
            adapter.SelectCommand = command;
            adapter.Fill(dtclubroom);  
            dataGridView2.DataSource = dtclubroom;
        }
        catch (Exception ex)
        {
            MessageBox.Show("error" + ex);
        }
        finally
        {
            myConnection.Close();
        }
    }
    private void button5_Click(object sender, EventArgs e)
    {
        SqlCommand command2 = new SqlCommand();
        try
        {
            myConnection.Open();
            command2.CommandText = "insert into employee (name,id) values (@name,@id)";
            command2.Connection = myConnection;
            command2.Parameters.AddWithValue("@name","Leon");
            command2.Parameters.AddWithValue("@id", "002");
            command2.ExecuteNonQuery();
			DataRow dr = dtclubroom.NewRow();
			dr["name"] = "Leon";
			dr["id"] = "002";
			dtclubroom.Rows.Add(dr);
        }
        catch (Exception  exc)
        {
            MessageBox.Show(exc.Message);
        }
        finally
        {
            myConnection.Close();
        }
        dataGridView2.DataSource = dtclubroom; //<- refresh datagridview
    }
