             int result;
              using (SqlConnection con = new SqlConnection(constr))
                    {
                    SqlCommand cmd = new SqlCommand("update Students set RegNo='" + RegNo.Text + "',Name='" + Name.Text + "',Address=" + Address.Text", con);
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                     } 
                    if (result == 1)
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:alert('Record Updated Successfully');", true);    
                        Response.Write("Record saved successfully");
                    }
                    Response.Redirect("~/WebForm1.aspx"); 
