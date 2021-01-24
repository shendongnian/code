        void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
              {
                 
            if(e.CommandName=="Update")
                {
            
            
               cmd = new SqlCommand("UPDATE custInfo SET lastLeak='4/5/2017' WHERE customerName=@customerName", cn);//get customer name from row like row.cells[index];
              if(e.CommandArgument != null)
                 cmd.Parameters.AddWithValue("@customerName", e.CommandArgument.ToString().Trim());//as customer name is in the first column it's the first cell which is 0th index
               cn.Open();
               cmd.ExecuteNonQuery();      
               cn.Close();
               GridView1.DataBind();// this will refresh the grid from database
            }
            
            }
