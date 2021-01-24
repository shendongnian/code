    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "UpdateLeak")
                {
                    if (e.CommandArgument != null)
                    {
                        int RowID = Convert.ToInt32(e.CommandArgument);
                        GridViewRow row = GridView1.Rows[RowID];
                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LeakConnection"].ConnectionString))
                        {
                            SqlCommand cmd = new SqlCommand("UPDATE Leak SET lastLeak='4/5/2017' WHERE CustomerName=@customerName", conn);
                            if (e.CommandArgument != null)
                                cmd.Parameters.AddWithValue("@customerName", row.Cells[0].Text.Trim());
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            BindLeaks();
    
                        }
    
                    }
                }
            }
    
