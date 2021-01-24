    SqlConnection cn = new SqlConnection("Data Source=srv;Initial Catalog=db;Integrated Security=True"))
        {
            foreach (DataGridViewRow row in salesOrdersDataGridView.SelectedRows)
            {                
                SqlCommand cmd = new SqlCommand("Insert into tbl (Ack,DateAcknowledged) Values (@Ack,@DateAcknowledged)",cn);
                cmd.Parameters.AddWithValue("@Ack", "Y");
                cmd.Parameters.AddWithValue("@DateAcknowledged", DateTime.Now.ToShortDateString());
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
    }
