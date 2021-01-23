    private void ListBox1_SelectedItemChanged(object sender, EventArgs e)
    {
        connection = new SqlConnection(connectionstring);
        try
        {
            connection.Open();
            var q = "SELECT * FROM Lanky WHERE Jménohráče  = @jh";
            var query = new SqlCommand(q, connection);
            query.Parameters.Add("@jh", ListBox1.SelectedValue.ToString())
            using (var dr = query.ExecuteReader())
            {
                
                ListBox1.Items.Clear();
                dr.Read();
                label8.Text = dr["Kills"].ToString();
                label9.Text = dr["Deaths"].ToString();
                label1.Text = dr["Jménohráče"].ToString();
                label2.Text = dr["Věk"].ToString();
                label3.Text = dr["Země"].ToString();
            }
            connection.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("error " + ex);
        }
    }
