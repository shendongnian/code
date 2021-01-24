    List<clsTableData> allFieldsList = (from g in ds.Tables["Default"].AsEnumerable()
                                                         select new clsTableData
                                                         {
                                                             tableName = g.Field<string>("tablename"),
                                                             custAccount = int.TryParse((g.Field<string>("accountNum")).ToString(), out result) ?
                                                                           Convert.ToInt32(g.Field<System.Int64>("accountNum")) :
                                                                           12345
                                                         }
                                                        ).ToList();
