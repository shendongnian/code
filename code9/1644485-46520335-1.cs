       public static void DB_GetMarks(int _UserID, int _YearID)
        {
            Dictionary<int, double> MarksArr = new Dictionary<int, double>();
            MarksArr.Add(1, 50);
            MarksArr.Add(2, 49);
            MarksArr.Add(3, 48);
            using (SqlConnection con = new SqlConnection(""))
            {
                try
                {
                    SqlCommand cmdQueryMarks = new SqlCommand();
                    cmdQueryMarks.Connection = con;
                    cmdQueryMarks.CommandText = "SELECT UserID, LernfeldID, SchuljahrID, Note "
                                               + "FROM UsersToLernfelder "
                                               + "WHERE USERID = @usrID "
                                               + "AND SchuljahrID = @YearID "
                                               + "ORDER BY LernfeldID ASC";
                    cmdQueryMarks.Parameters.AddWithValue("@usrID", _UserID);
                    cmdQueryMarks.Parameters.AddWithValue("@YearID", _YearID);
                    SqlDataAdapter da = new SqlDataAdapter(cmdQueryMarks);
                    DataTableMapping dtm = da.TableMappings.Add("Table", "UsersToLernfelder");
                    dtm.ColumnMappings.Add("UserID", "User");
                    dtm.ColumnMappings.Add("LernfeldID", "Lernfeld");
                    dtm.ColumnMappings.Add("SchuljahrID", "Schuljahr");
                    DataTable tbl = new DataTable();
                    da.Fill(tbl);
                    int i = 0;
                    foreach (var item in MarksArr)
                    {
                        DataRow Result = (from DataRow dr in tbl.Rows where Convert.ToInt32(dr["USERID"]) == item.Key select dr).FirstOrDefault();
                        if (Result == null)
                        {
                            DataRow newEntry = tbl.NewRow();
                            newEntry["UserID"] = item.Key;
                            newEntry["Lernfeld"] = i + 1;
                            newEntry["Schuljahr"] = _YearID;
                            newEntry["Note"] = item.Value;
                            tbl.Rows.Add(newEntry);
                        }
                        else
                        {
                            foreach (DataRow _dr in tbl.Rows)
                            {
                                if (Convert.ToInt32(_dr["UserID"]) == item.Key)
                                {
                                    _dr["marks"] = item.Value;
                                }
                            }
                        }
                        i++;
                    }
                    SqlCommandBuilder cmb = new SqlCommandBuilder(da);
                    da.Update(tbl);
                }
                catch (Exception ex)
                {
                    _Err = ex.Message;
                }
            }
        }
