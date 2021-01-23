    using (HttpClient client = new HttpClient())
    {
        var response = client.GetStringAsync("My URI").Result;
        JObject o = JObject.Parse(response);
        Value1 = (string)o.SelectToken("PressureReading");
        Value2 = (string)o.SelectToken("PressureTrend");
    }
