            string query = "SELECT ServiceTicketReportID, InspectedBy FROM tblServiceTicketReport WHERE ServiceTicketID = 123; SELECT RepCrewID, Firstname, Lastname FROM tblRepCrew";
            string constr = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
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
                            ListItem item = new ListItem();
                            item.Text = sdr["Lastname"].ToString() + ' ' + sdr["Firstname"].ToString();
                            item.Value = sdr["RepCrewID"].ToString();   
                      if ( *something* == sdr["RepCrewID"].ToString() )
                            {                        
                                item.Selected = true;
                            }
                            ddlCrew.Items.Add(item);
                        }
                    }
                    con.Close();
                }
            }
            ddlCrew.Items
