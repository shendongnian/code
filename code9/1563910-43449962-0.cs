    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        var sql = "insert into dbo.customer ...";
        using (var con = new SqlConnection(ss))
        {
            var cmd = new SqlCommand(sql , con);
            con.Open();
            cmd.ExecuteScalar();
            MessageBox.Show("Welcome to our gym");
        }
    }
