    List<clsTableData> allFieldsList = (from g in ds.Tables["Default"].AsEnumerable()
                                                         select new clsTableData
                                                         {
                                                             tableName = g.Field<string>("tablename"),
                                                             custAccount = g["accountNum"].GetType() == typeof(System.Int64) ?
                                                                           Convert.ToInt32(g.Field<System.Int64>("accountNum")) :
                                                                           12345
                                                         }
                                                        ).ToList();
