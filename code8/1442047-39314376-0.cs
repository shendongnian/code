    SqlConnection con=new SqlConnection(@"Data Source=.\SqlExpress;Initial      Catalog=DatabaseName;Integrated Security=True"); 
    
     SqlCommand cmd = new SqlCommand();
    
    if (dataGridView1.Rows.Count > 1 && dataGridView1.SelectedRows[0].Index != dataGridView1.Rows.Count - 1)
    
     {
    
     delcmd.CommandText = "DELETE FROM table_Name WHERE Column_Name=" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "";
    
                    con.Open();
    
                    delcmd.Connection = con;
    
                    delcmd.ExecuteNonQuery();
    
                    con.Close();
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
    
                    MessageBox.Show("Row has been Deleted");
    
                    
                }
