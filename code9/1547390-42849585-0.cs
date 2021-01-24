     StringBuilder html = new StringBuilder();
        			html.Append("<table border = '1'><thead><tr><td>Client Account 
    
    Number</td><td>Client Name</td></tr></thead>");
			SqlCommand command = new SqlCommand(@"EXEC [dbo].[CTLC_SearchClient] '" + SearchVal + "';");
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            command.Connection = conn;
            SqlDataReader readers = command.ExecuteReader();
            if (readers.HasRows)
            {
                while (readers.Read())
                {
					html.Append("<tr>");
					html.Append("<td>");
                    html.Append(string.Format("<a href='ClientInfo.aspx?ClientNumber={0}'>{0}</a>", readers.GetString(0)));
					html.Append("</td>");
					html.Append("<td>");
                    html.Append(readers.GetString(1));
					html.Append("</td>");
                }
                conn.Close();
            }
			
			html.Append("</table>");
			tableClientSearch.Controls.Add(new Literal { Text = html.ToString() });
