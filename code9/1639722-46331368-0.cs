     if (ddlSparesInfo.SelectedValue == "Fast Moving Spares")
                {
                    lblMessage.Text = "";
                    try
                    {
                        SqlCommand cmd = new SqlCommand("getFastMovingSpares", DBConn.Conn);
                        DBConn.OpenConn();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
    
                            Dictionary<string, int> faults = new Dictionary<string, int>();
                            while (dr.Read())
                            {
                                string cellValue = dr.GetString(7);
                                string[] splitFaults = cellValue.Split(',');
                                for (int i = 0; i < splitFaults.Length; i++)
                                {
                                    string currentFault = splitFaults[i];
                                    if (faults.Keys.Any(x => x == currentFault))
                                    {
                                        faults[currentFault] += 1;
                                    }
                                    else
                                    {
                                        faults.Add(currentFault, 1);
                                    }
                                }
                            }
    
    
                            Response.Write("<table>");
                            foreach (var fault in faults)
                            {
    
                                Response.Write("<tr>");
                                Response.Write("<td>");
                                Response.Write("<p>" + fault.Key + "<p>");
                                Response.Write("</td>");
                                Response.Write("<td>");
                                Response.Write("<p>" + fault.Value + "<p>");
                                Response.Write("</td>");
                                Response.Write("</tr>");
                            }
    
                            Response.Write("</table>");
                        }
                    }
                    catch (Exception)
                    {
    
                        throw;
                    }
                    finally
                    {
                        DBConn.CloseConn();
    
                    }
    
    }
