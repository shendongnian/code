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
    
        try
        {
            DataSet ds = new clsiCMSBLBase().GetListData(ref err, sqlParam, procedureName);
            String JSONString = String.Empty;
    
            //JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
    
            if (ds.Tables[table].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[table];
                JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
            }
    
            return JSONString;
        }
        catch (Exception)
        {
            return "Error";
        }
    }
