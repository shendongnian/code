    public static class Api
    {
    public static ValCurs GetValCursByDate(DateTime date)
    {
        var client = new RestClient("http://bnm.md"); //request
        var request = new RestRequest("ro/official_exchange_rates/get_xml=1&date="+date.ToString(), Method.GET); //request
        var response = client.Execute<ValCurs>(request);//deserialization
        if (response.ErrorException != null) { return null; } //throw exception
        return response.Data;
    }
    public static Valute GetValuteByDate(DateTime date, string valuteCharCode)
    {
        var curs = GetValCursByDate(date);
        Valute valuteByDate = curs.FirstOrDefault(valute => valute.CharCode.Equals(valuteCharCode));
        return valuteByDate;
    }
    public static Valute GetMaxValuteByPeriod(DateTime startDate, DateTime endDate, string charCode)
    {
        var totalDays = (endDate-startDate).TotalDays;
        List<Valute> result = new List<Valute>(totalDays);
        for(int i = 0; i < totalDays; i++)
        {
             result.Add(GetValuteByDate(startDate.AddDays(i), charCode);
        }
        var maxVal = result.Max(p => p.<put here property>);
        
        return maxVal;
    }
    }
