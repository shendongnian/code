        try
        {
            string sqlQuery = "[dbo].[EditPharmacyItems]";
            int y = 0;
            mycon.Open();
            for (int i = 0; i<dataGridView1.Rows.Count; i++)
            {
                SqlCommand cmd5 = new SqlCommand(sqlQuery, mycon);
                cmd5.CommandType=CommandType.StoredProcedure;
                cmd5.Parameters.AddWithValue("@Quantity",dataGridView1.Rows[y].Cells[4].Value);
                cmd5.Parameters.AddWithValue("@Sold",dataGridView1.Rows[y].Cells[4].Value);
                cmd5.Parameters.AddWithValue("@ItemName",dataGridView1.Rows[y].Cells[1].Value);
                cmd5.ExecuteNonQuery();
                y += 1;
            }
            mycon.Close();
        }
