    public void GetFlowRestrictionDiametersValues()
        {
            ModalPopupUpdate.Show();
            try
            {
                List<DropDownListClass> ListFlowRestrictionDiametersValues = new List<DropDownListClass>();
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["someString"].ToString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT 
                                                       case 
                                                          when Diameter = '2.5' then 'Open 2.5'
                                                          when Diameter = '2' then 'Red. w/45° 2' 
                                                          else [Stream Restriction] end as DisplayName,
                                                       Diameter AS [Value]    
                                                     FROM [tblNozzleDetail] where Diameter != 0 ORDER BY DIAMETER", conn);
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ListFlowRestrictionDiametersValues.Add(new DropDownListClass()
                                {
                                    DisplayName = (string)reader["DisplayName"],
                                    Value = (string)reader["Value"] 
                                });
                            }
                        }
                        reader.Close();
                    }
                }
                cbFlowRestrictionDiameterModal.Items.Clear();
                cbFlowRestrictionDiameterModal.Items.Insert(0, new ListItem("(Select)", "0"));
                foreach (var item in ListFlowRestrictionDiametersValues)
                {
                    cbFlowRestrictionDiameterModal.Items.Add(new ListItem(item.DisplayName, item.Value));
                }
            }
            catch (SqlException ex)
            {
                //Log exception
            }
        }
        
