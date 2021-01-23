     public List<SelectListItem> GetCity(ref string StateCode, string ZipCode)
            {
                List<SelectListItem> lstCity = new List<SelectListItem>();
                try
                {
    
                    SqlParameter[] parameters = { new SqlParameter("@StateCode", StateCode), new SqlParameter("@ZipCode", ZipCode) };
                    DataSet dsCity = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "GetCityByStateCodeZipCode", parameters);
    
                    if (dsCity != null && dsCity.Tables.Count > 0 && dsCity.Tables[0].Rows.Count > 0)
                    {
                        lstCity = (from drCity in dsCity.Tables[0].AsEnumerable()
                                                      select new SelectListItem { Text = drCity["City"].ToString(), Value = drCity["City"].ToString() }).ToList();
    
                        if (string.IsNullOrEmpty(StateCode))
                        {
                            StateCode = dsCity.Tables[0].Rows[0]["StateCode"].ToString();
                        }
                       
                    }
                    return lstCity;
                }
                catch (Exception ex)
                {
                    return lstCity;
                }
            }
