            string query = "SELECT ServiceTicketReportID, InspectedBy FROM tblServiceTicketReport WHERE ServiceTicketID = 123; SELECT RepCrewID, Firstname, Lastname FROM tblRepCrew";
            string constr = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
            string something = null; 
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                           something = sdr["InspectedBy"].ToString(); 
                        }
                        if (sdr.NextResult())
                        {
                        while (sdr.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = sdr["Lastname"].ToString() + ' ' + sdr["Firstname"].ToString();
                            item.Value = sdr["RepCrewID"].ToString();   
                      if ( something == sdr["Lastname"].ToString() + ' ' + sdr["Firstname"].ToString() )
                            {                        
                                item.Selected = true;
                            }
                            ddlCrew.Items.Add(item);
                        }
                      }
                    }
                    //using auto close the connection
                    //con.Close();
                }
            }
            ddlCrew.Items
