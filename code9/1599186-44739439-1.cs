    public async static Task<RootObject[]> GetLineName(int linecode)
    {
        var http = new HttpClient();
        var response = await http.GetAsync("http://telematics.oasa.gr/api/?act=getLineName&p1=962");
        var result = await response.Content.ReadAsStringAsync();
        var serializer = new DataContractJsonSerializer(typeof(RootObject[]));
        var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
        var data = (RootObject[])serializer.ReadObject(ms);
        return data;
    }
    //...
     var myLines = await LineName.GetLineName(92);
     var myLine = myLines.FirstOrDefault();
