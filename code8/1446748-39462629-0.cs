    object obj = DeteailsEmp(param1, param2).Result; // Force result
    public async Task<object> DeteailsEmp(string emp_xml, string emp_error)
    {
        XDocument xml;
        try
        {
            xml = XDocument.Parse((await GetXml(emp_xml)).ToString()); // Since GetXml is now an asynchronous method, you need to get the result first before calling ToString() or you can use GetXml(emp_xml).Result.ToString()
        }
        catch
        {
            xml = XDocument.Load(emp_error);
        }
        var detail = from query in xml.Descendants("emp")
                        select new Data.Emp
                        {
                            Name = (string)query.Element("name").Value,
                            Age = (string)query.Element("age").Value,
        return detail ;
    }
    async static Task<XDocument> GetXml(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetStreamAsync(url);
            return XDocument.Load(response);
        }
    }
