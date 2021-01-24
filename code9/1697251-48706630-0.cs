        public static string sp_GetCCard_Limit(string docRoot)
        {
            DataSet dataSet = cmdExecutor.ExecuteDataSet("sp_GetCCard_Limit", docRoot);
            if(dataSet.Tables.Count > 0)
            {
                DataTable dTable = dataSet.Tables[0];
                if(dTable.Rows.Count > 0)
                {
                    return dTable.Rows[0].["VALUE"].ToString();
                }
            }
            return ""; // default value for if no data found.
        }
