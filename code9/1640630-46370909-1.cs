    using (SqlConnection conn = new SqlConnection())
     {
                //Connection string
                conn.ConnectionString = ConnectionString.DataSourceString;
                //Create adapter and assign store procedure name
                SqlCommand cmmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure
                };
                
                // Assign to Command type
                //exception is caught because it cannot find Stored Procedure
                //Insert parameters into row from input text
                cmmd.CommandText = "GetTeam";
        // Send parameter            
    cmmd.Parameters.AddWithValue("@PGetDayTeam",
     ShiftParameterTextBox.Text.Trim());
                cmmd.Connection = conn;
                try
                {
                    conn.Open();
                    //If we do not receive any records 
                    GridView2.EmptyDataText = "No Records Found";
                    GridView2.DataSource = cmmd.ExecuteReader();
                    GridView2.DataBind();
                   
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    // Close and dispose connection
                    conn.Close();
                    conn.Dispose();
                }
     // select from grid
    protected void GridView2_SelectedIndexChanging(Object sender, GridViewSelectEventArgs e)
    {
    
    GridViewRow row = GridView2.Rows[e.NewSelectedIndex];
        
            string GetTeam = row.Cells[2].Text;
           // You can use it in viewstate or what you choose.
            ViewState["GetTeam"] = GetTeam;
    }
