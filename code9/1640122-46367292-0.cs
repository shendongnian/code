    using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["TESTCONN"].ConnectionString))
    {
        using (SqlCommand cmd = new SqlCommand("[Model].[TaskRecord_GetAll]", sqlcon))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Period", period);
    
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
    			DataSet ds = new DataSet();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
    
                da.Fill(ds);
                dt1 = ds.Tables[0];
                dt2 = ds.Tables[1];
    
                List<DataRow> list = dt2.AsEnumerable().ToList();
    
                List<string> colList = new List<string>();
                foreach(DataRow row in list)
                {
                    colList.Add(row.ItemArray[0].ToString());
                }
    
                var jsonString = JsonConvert.SerializeObject(new
                {
                    columns = colList
                }, Formatting.Indented);
    
                ds.Tables.Remove(dt2);
    
                string json = JsonConvert.SerializeObject(ds, Formatting.Indented);
    
                JObject o1 = JObject.Parse(jsonString);
                JObject o2 = JObject.Parse(json);
    
                o1.Merge(o2, new JsonMergeSettings
                {
                    // union array values together to avoid duplicates
                    MergeArrayHandling = MergeArrayHandling.Union
                });
                string jsonResult = o1.ToString();
    
                return jsonResult;
            }
        }
    }
