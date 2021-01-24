    public void TestMethod1()
    {
        var url = "http://data.cocorahs.org/cocorahs/export/exportreports.aspx?ReportType=Daily&Format=csv&Date=1/1/2000&Station=UT-UT-24";
        var client = new System.Net.WebClient();
        
        using (var stream = client.OpenRead(url))
        {
            using (var reader = new StreamReader(stream))
            {
                var str = reader.ReadToEnd().Split('\n').Where(x => !string.IsNullOrEmpty(x)).LastOrDefault();
                Debug.WriteLine(str);
                Assert.IsNotEmpty(str);
            }
        }
    }
