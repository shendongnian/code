        [WebMethod]
        public static string data_call()
        {
            string result="";
            Data td=new Data();
            List<spselect_data_Result> selectdata=td.spselect_data().ToList();
            DataTable dt=new DataTable();
            dt.Columns.Add("RegValues",typeof(string));
            dt.Columns.Add("StartDate",typeof(DateTime));
            dt.Columns.Add("EndDate",typeof(DateTime));
            foreach(var add in selectdata)
            {
                dt.Rows.Add(add.RegValues,add.StartDate,add.EndDate);
            }
            result=DataSetToJSON(dt);
            return result;
        }
          public static string DataSetToJSON(DataTable dt)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            object[] arr = new object[dt.Rows.Count + 1];
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                arr[i] = dt.Rows[i].ItemArray;
            }
           // dict.Add(dt.TableName, arr);
            dict.Add("response", arr);
            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Serialize(dict);
              
        }
