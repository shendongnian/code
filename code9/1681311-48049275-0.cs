       try
       {
            SqlConnection connection = new SqlConnection(conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            connection.Open();
            adapter.DeleteCommand = connection.CreateCommand();
            adapter.DeleteCommand.CommandText = "Delete from Stock_Jewelry where ID =@id";
            adapter.DeleteCommand.Parameters.AddWithValue("@id", txt_ID.Trim());
            adapter.DeleteCommand.ExecuteNonQuery();
            MessageBox.Show("Row(s) deleted !! ");
        }
        catch (Exception ex)
        {
                MessageBox.Show(ex.ToString());
        }
