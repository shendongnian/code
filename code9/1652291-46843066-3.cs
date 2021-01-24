        private async void GetHomeItems()
        {
            var client = new HttpClient();
            var url = new Uri(IAMSUrl + "/GetProductSRP");
            var content = new StringContent("{CustomerCode: 'test'}");
        
            var response = await client.PostAsync(url, content);
            //As string
            var result = await response.Content.ReadAsStringAsync();
            //As Object
             var objResult = JsonConvert.DeserializeObject<SrpResult>(result);
             DataTable dt = objResult.ToDataTable<SrpResult>();
        }
    
    public DataTable ToDataTable<T>(this IList<T> data)
    {
        PropertyDescriptorCollection props =
        TypeDescriptor.GetProperties(typeof(T));
        DataTable table = new DataTable();
        for(int i = 0 ; i < props.Count ; i++)
        {
        PropertyDescriptor prop = props[i];
        table.Columns.Add(prop.Name, prop.PropertyType);
        }
        object[] values = new object[props.Count];
        foreach (T item in data)
        {
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = props[i].GetValue(item);
        }
        table.Rows.Add(values);
        }
        return table;        
    }
