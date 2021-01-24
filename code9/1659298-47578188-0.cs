    public static string GenerateSafeSelectAllQueryString(string tableName, SQLDateConversionStyle dateConvertType) {
            var retval = new StringBuilder();
            using (SqlConnection con = new SqlConnection(PSQLServerUtilities.ConnectionStringStatic)) {
                string query = "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME=@tableName ORDER BY ORDINAL_POSITION ASC;";
                try {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(query, con)) {
                        com.Parameters.AddWithValue("tableName", tableName);
                        using (SqlDataReader reader = com.ExecuteReader()) {
                            if (reader.HasRows) {
                                using (DataTable dt = new DataTable(tableName)) {
                                    dt.Load(reader);
                                    foreach (DataRow row in dt.Rows) {
                                        retval.Append((row[1].ToString() == "datetime") ?
                                            $"CONVERT(varchar, {row[0].ToString()}, {(int)dateConvertType}) AS '{row[0].ToString()}', " : $"{row[0].ToString()}, ");
                                    }
                                    retval.Length -= 2;
                                }
                            }
                        }
                    }
                } catch (Exception ex) {
                    throw ex;
                } finally {
                    con.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
            return retval.ToString();
        }
        /// <summary>
        /// Different types of converting SQL DateTime to varchar
        /// Source: https://www.w3schools.com/sql/func_sqlserver_convert.asp
        /// </summary>
        public enum SQLDateConversionStyle {
            /// <summary>
            /// Format: mon dd yyyy hh:miAM/PM
            /// </summary>
            Default = 100,
            /// <summary>
            /// Format: mm/dd/yyyy
            /// </summary>
            US = 101,
            /// <summary>
            /// Format: hh:mm:ss
            /// </summary>
            HoursOnly = 108,
            /// <summary>
            /// Format: yyyy/mm/dd
            /// </summary>
            Japan = 111,
            /// <summary>
            /// Format: yyyy-mm-dd hh:mi:ss
            /// </summary>
            ODBCCanonical = 120,
            /// <summary>
            /// Format: yyyy-mm-dd hh:mi:ss.mmm
            /// </summary>
            ODBCCanonicalMillis,
            /// <summary>
            /// Format: yyyy-mm-ddThh:mi:ss.mmmZ
            /// </summary>
            ISO8601 = 127
        }
