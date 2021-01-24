      public static ClsPayeDetails get_paydetail_byrow(int rowno)
            {
                    string sql = "SELECT * FROM s07_01_payeDetails WHERE row_no='" + rowno + "'";
                    DataRow dr = LogIn.HR_Connection.GetSingleRow(sql);
                    ClsPayeDetails obj_det = null;
                    if (dr != null)
                    {
                        obj_det = new ClsPayeDetails(
                            decimal.Parse(dr["reducing_value"].ToString()),
                            dr["financial_year"].ToString(),
                            decimal.Parse(dr["lower_limit"].ToString()),
                            decimal.Parse(dr["upper_limit"].ToString()),
                            decimal.Parse(dr["percentage"].ToString())
                            );
                    }
                    else
                    {
                        MessageBox.Show("This row does not exist !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                return obj_det;
            }
