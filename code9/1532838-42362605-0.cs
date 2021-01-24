    [WebMethod]
        public static String GetRowData_Tables(string procedureName, string paramstr, int table)
        {
            string[] parameters = paramstr.Split('~');
            string err = string.Empty;
            int len = parameters.Length;
            SqlParameter[] sqlParam = new SqlParameter[len];
            for (int i = 0; i < len; i++)
            {
                string[] paramWithValue = parameters[i].Split('$');
                string param = paramWithValue[0].ToString();
                string value = paramWithValue[1].ToString();
                sqlParam[i] = new SqlParameter { ParameterName = param, Value = value };
            }
    
            DataSet ds = new clsiCMSBLBase().GetListData(ref err, sqlParam, procedureName);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[table];
                    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, dr[col].ToString());
                        }
                        rows.Add(row);
                    }
                    String Val = serializer.Serialize(rows);
                    if (Val != "")
                    {
                        return (Val);
                    }
                    else
                    {
                        return "Error";
                    }
                }
            }
    
            return "";
        }
