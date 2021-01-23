    try
            {
                mycon.Open();
                int y = 0;
                for (int i = 0; i<dataGridView1.Rows.Count; i++)
                {
    
                    string sql = "UPDATE [dbo].[Pharmacy_Items] Set Quantity= Quantity + @Quantity , Sold= Sold - @Sold where ItemName=@ItemName";
    
                    using (SqlCommand cmd5 = new SqlCommand(sql, mycon))
                    {
                        cmd5.CommandType = CommandType.Text;
                        var qunatityParam = new SqlParameter("Quantity", SqlDbType.Int);
                        var soldParam = new SqlParameter("Sold", SqlDbType.Int);
                        var itemNameParam = new SqlParameter("ItemName", SqlDbType.VarChar);
                        qunatityParam.Value = dataGridView1.Rows[y].Cells[4].Value;
                        soldParam.Value = dataGridView1.Rows[y].Cells[4].Value;
                        itemNameParam.Value = dataGridView1.Rows[y].Cells[1].Value;
                        cmd5.Parameters.Add(qunatityParam);
                        cmd5.Parameters.Add(soldParam);
                        cmd5.Parameters.Add(itemNameParam);
                        cmd5.ExecuteNonQuery();
                    }
    
                    y += 1;
                }
                mycon.Close();
            } 
