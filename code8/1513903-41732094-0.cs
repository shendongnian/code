    using (SqlConnection con = new SqlConnection(connectionString))
    {
        string deletequery = " DELETE FROM StudentBook WHERE BookREF = @Book_Ref ";
        using (SqlCommand command = new SqlCommand(deletequery, con))
        {
            using (SqlDataAdapter adapter3 = new SqlDataAdapter(command))
            {
                con.Open();
                DataTable dt = new DataTable();
                command.Parameters.AddWithValue("@Book_Ref", Book_Ref.SelectedItem.ToString());
                int rowsAffected = command.ExecuteNonQuery();
                adapter3.Update(dt);
                dt.AcceptChanges();
                if (rowsAffected > 0) {
                    MessageBox.Show(String.Format("{0} rows deleted.", rowsAffected));
                }
                else
                {
                    MessageBox.Show(String.Format("no rows deleted, bookref: {0}", Book_Ref.SelectedItem.ToString()));
                }
            }
        }
        con.Close();
    }
