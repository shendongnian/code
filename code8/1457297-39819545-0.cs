     public SqlConnection getConn()
        {
            return new SqlConnection(getConnString());
        }
        public string getConnString()
        {
            return @"Data Source=lily.arvixe.com;Initial Catalog=WM_Crawler;Persist Security Info=True;User ID={myUser};Password={MyPass};Connection Timeout=7000";
        }
     //This is how you flush a DataTable
     public  void saveDataTable(string tableName, DataTable table)
        {
            
            using (SqlConnection conn = getConn())
            {
                conn.Open();
                using (var bulkCopy = new SqlBulkCopy(conn))//, SqlBulkCopyOptions.KeepIdentity))
                {
                    // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
                    foreach (DataColumn col in table.Columns)
                    {
                       bulkCopy.ColumnMappings.Add(col.ColumnName, "["+col.ColumnName+"]");
                    }
                    bulkCopy.BulkCopyTimeout = 8000;
                    bulkCopy.DestinationTableName = tableName;
                    bulkCopy.BatchSize = 10000;
                    bulkCopy.EnableStreaming = true;
                    //bulkCopy.SqlRowsCopied += BulkCopy_SqlRowsCopied;
                    //bulkCopy.NotifyAfter = 10000;
                   bulkCopy.WriteToServer(table);
                }
                conn.Close();
            }
        }
        //this is how you select one field from one row
        public object scalar(string sql)
        {
            object ret;
            using (SqlConnection conn = getConn())
            {
                conn.Open();
                using (SqlCommand com = conn.CreateCommand())
                {
                    com.CommandText = sql;
                    ret = com.ExecuteScalar();
                }
                conn.Close();
            }
            return ret;
        }
        //this is how you execute a command using SQL string (admin functions)
        public void nonQuery(string sql)
        {
            using(SqlConnection conn = getConn())
            {
                conn.Open();
                using(SqlCommand com = conn.CreateCommand())
                {
                    com.CommandText = sql;
                    com.CommandTimeout = 5900;
                    com.ExecuteNonQuery();
                }
                conn.Close();
            }
            
        }
        // This is how you execute a query using a predefined, parameterized command (user input)
        public void nonQuery_With_Command(SqlCommand com)
        {
            using (SqlConnection conn = getConn())
            {
                conn.Open();
                using (com)
                {
                    com.Connection = conn;
                    com.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        //this is how you execute several commands under one connection (sql or stored procedure)
        public void nonQuery_List_Command(List<SqlCommand> comList)
        {
            using (SqlConnection conn = getConn())
            {
                conn.Open();
                foreach (SqlCommand com in comList)
                {
                   using (com)
                    {
                        com.Connection = conn;
                        try
                        {
                            com.ExecuteNonQuery();
                        }
                        catch(Exception n1)
                        {
                            Console.WriteLine(n1.Message);
                            Console.WriteLine(com.Parameters[1].Value.ToString());
                        }
                    }
                    }
                conn.Close();
            }
        }
        //This returns column names from a specific table (example of a datareader)
        private List<string> get_Column_Names(string tableName)
        {
            List<string> ret = new List<string>();
            using (SqlConnection conn = getConn())
            {
                conn.Open();
                using(SqlCommand com = conn.CreateCommand())
                {
                    com.CommandText = "select column_Name from INFORMATION_SCHEMA.COLUMNS where table_Name = '" + tableName + "'";
                    com.CommandTimeout = 600;
                    SqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        ret.Add(Convert.ToString(read[0]));
                    }
                }
                conn.Close();
            }
            return ret;
        }
        //This converts a reader to a class using fields. It is not optimized and is inefficient, but allows you to see what's happening. Yu can optimize it yourself
        public static object[] sql_Reader_To_Type(Type t, SqlDataReader r)
        {
            List<object> ret = new List<object>();
            while (r.Read())
            {
                FieldInfo[] f = t.GetFields();
                object o = Activator.CreateInstance(t);
                for (int i = 0; i < f.Length; i++)
                {
                    string thisType = f[i].FieldType.ToString();
                    switch (thisType)
                    {
                        case "System.String":
                            f[i].SetValue(o, Convert.ToString(r[f[i].Name]));
                            break;
                        case "System.Int16":
                            f[i].SetValue(o, Convert.ToInt16(r[f[i].Name]));
                            break;
                        case "System.Int32":
                            f[i].SetValue(o, Convert.ToInt32(r[f[i].Name]));
                            break;
                        case "System.Int64":
                            f[i].SetValue(o, Convert.ToInt64(r[f[i].Name]));
                            break;
                        case "System.Double":
                            double th;
                                if (r[f[i].Name].GetType() == typeof(DBNull))
                                {
                                    th = 0;
                                }
                                else
                                {
                                    th = Convert.ToDouble(r[f[i].Name]);
                                }
                            }
                            try { f[i].SetValue(o, th); }
                            catch (Exception e1)
                            {
                                throw new Exception("can't convert " + f[i].Name + " to double - value =" + th);
                            }
                            break;
                        case "System.Boolean":
                            f[i].SetValue(o, Convert.ToInt32(r[f[i].Name]) == 1 ? true : false);
                            break;
                        case "System.DateTime":
                            f[i].SetValue(o, Convert.ToDateTime(r[f[i].Name]));
                            break;
                        default:
                            throw new Exception("Missed data type in sql select ");
                    }
                }
                ret.Add(o);
            }
            return ret.ToArray();
        }
        //these are basic (rudimentary) ways of converting class to DataTable
        public static DataTable create_DataTable_From_Generic_Class(Type t)
        {
            DataTable d = new DataTable();
            PropertyInfo[] pI = t.GetProperties();
            for (int i = 0; i < pI.Length; i++)
            {
                DataColumn dC = new DataColumn(pI[i].Name, pI[i].PropertyType);
                d.Columns.Add(dC);
            }
            return d;
        }
        public static object[] Create_Datatable_Row_From_Generic_Class(Type t, object instance, DataTable dt)
        {
            PropertyInfo[] p = t.GetProperties();
            object[] ret = new object[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                var temp = t.GetProperty(dt.Columns[i].ColumnName);
                ret[i] = temp.GetValue(instance);
            }
           return ret;
        }
