    public string ConvertDataTabletoString(DataTable dt)
            {
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                serializer.MaxJsonLength = Int32.MaxValue;
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;
                if (dt.Rows.Count == 0)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                        row.Add(col.ColumnName, "");
                    rows.Add(row);
                    return "empty" + serializer.Serialize(rows);
                }
    
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                    return serializer.Serialize(rows);
                }
            }
