     string constr = ConfigurationManager.ConnectionStrings["Server=CONNECTIONINFO"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * [firstName], [lastName]
                                        FROM [dbo].[Players]
                                        WHERE [position] = 'QB'
                                        ORDER BY [firstName] ASC"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    ddlPlayers.DataSource = cmd.ExecuteReader();
                    ddlPlayers.DataTextField = "firstName";
                    ddlPlayers.DataValueField = "PlayerId";
                    ddlPlayers.DataBind();
                    con.Close();
                }
            }
            ddlCustomers.Items.Insert(0, new ListItem("--Select Player--", "0"));
