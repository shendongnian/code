    public List<ViewRoleModules> GetSiteRoleModulesViews(int _ModuleId)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Admin"].ConnectionString))
                {
                    List<ViewRoleModules> RoleList = new List<ViewRoleModules>();
                    SqlCommand com = new SqlCommand("MEDEIL_SiteRoleModules_SelectOne", conn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@ModuleID", _ModuleId);
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
    
                    conn.Open();
                    da.Fill(dt);
                    conn.Close();
                    foreach (DataRow dr in dt.Rows)
                    {
    
                        RoleList.Add(
    
                            new ViewRoleModules
                            {
                                //RoleID = Convert.ToInt32(dr["RoleID"]),
                                RoleName = Convert.ToString(dr["RoleName"])
                                //*****Included ModuleID Here*****
                                ModuleId = _ModuleId;
                            }
                        );
                    }
    
                    return RoleList;
                }
            }
