    private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedItem == null)
                return;
            DataRowView rowview = (DataRowView)dataGrid1.SelectedItem;
            NpgsqlConnection con = new NpgsqlConnection("Server=10.0.5.22;Port=5432;Database=TEST_DB;User Id=postgres;Password=test;");
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("delete from Product where productcode='" + rowview["productcode"] + "'", con);
            cmd.ExecuteNonQuery();  // here it is showing error as ERROR: 42601: syntax error at or near ":"
            con.Close();
        }
