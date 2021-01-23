	private void loadProcInfo(string procid)
	{
		try
		{
			using(SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString))
			using(SqlCommand query = new SqlCommand("SELECT * FROM dbo.Book1 WHERE ID = @bookId", con))
			{
				// added parameter
				query.Parameters.Add(new SqlParameter("@bookId", SqlDbType.Int){Value = procid});
				con.Open(); // missing
				//ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('"+query+"');", true);
				using (SqlDataReader procinfoload = query.ExecuteReader())
				{                    
					if (procinfoload.Read())
					{
						ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('IT WORKED');", true);
						Id.Text = procinfoload.GetValue(0).ToString();
					}
					else
					{
						ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('not success!');", true);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex + "');", true);
			//MessageBox.Show(ex.Message);
		}
	}
