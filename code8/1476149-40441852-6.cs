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
                        var qunatityParam = new SqlParameter{Value=dataGridView1.Rows[y].Cells[4].Value, SqlDbType=SqlDbType.Int, ParameterName="Quantity"};
                        var soldParam = new SqlParameter{Value=dataGridView1.Rows[y].Cells[4].Value, SqlDbType = SqlDbType.Int, ParameterName = "Sold"};
                        var itemNameParam = new SqlParameter{Value=dataGridView1.Rows[y].Cells[1].Value,SqlDbType = SqlDbType.VarChar, ParameterName = "ItemName"};
                        
                        cmd5.Parameters.Add(qunatityParam);
                        cmd5.Parameters.Add(soldParam);
                        cmd5.Parameters.Add(itemNameParam);
                        cmd5.ExecuteNonQuery();
                    }
    
                    y += 1;
                }
                mycon.Close();
            } 
