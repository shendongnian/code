    using(var con = new SqlConnection(your conn string))
    {    
             con.Open();
             for (int i = 0; i < dataPOS.Rows.Count; i++)
             {
                dataPOS.Rows[i].Selected = true;
                cmd = new SqlCommand(@"INSERT INTO TRANSACTIONS (TransactionCode,TransactionDate,ItemCode,ItemName,Quantity,Price,Total)
                                     VALUES
                                        ('"+ dataPOS.SelectedRows[0].Cells[0].Value.ToString() +"' , '"+ dataPOS.SelectedRows[0].Cells[1].Value.ToString() +"' , '"+ dataPOS.SelectedRows[0].Cells[2].Value.ToString() +"' , '"+ dataPOS.SelectedRows[0].Cells[3].Value.ToString()+"' , '"+ dataPOS.SelectedRows[0].Cells[4].Value.ToString() +"' '"+ dataPOS.SelectedRows[0].Cells[5].Value.ToString() +"' , '"+ dataPOS.SelectedRows[0].Cells[6].Value.ToString() +"')", con);
                cmd.ExecuteNonQuery();
                dataPOS.Rows[i].Selected = false;
             }
             con.Close();
    }
