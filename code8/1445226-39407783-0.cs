        string query_select_id = "SELECT * from table1 WHERE column1=@value";
        SqlConnection con = new SqlConnection(ConString);
        try
        {
            con.Open();
            SqlCommand createCommand = new SqlCommand(query_select_id, con);
            //createCommand .Parameters.AddWithValue("@value", SqlDbType.Int).Value=Convert.ToInt32(textbox.Text);
            createCommand .Parameter.AddWitheValue("@value",textbox.Text);
            SqlDataReader dr = createCommand.ExecuteReader();
            while (dr.Read())
            {
                intvalue= dr.GetInt32(12); 
            // 12 is the index of a column in table of the value I wanna get
            }
            con.Close();
            textboxvalue.Text = intvalue.ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
