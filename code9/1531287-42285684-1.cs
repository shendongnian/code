    public async static Task<List<RootObject>> Get()
    {
        var http = new HttpClient();
        var response = await http.GetAsync("http://bearlike-attackers.000webhostapp.com/wp-json/wp/v2/posts?search=TEST");
        var result = await response.Content.ReadAsStringAsync();
        var serializer = new DataContractJsonSerializer(typeof(List<RootObject>));
        var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
        var list = (List<RootObject>)serializer.ReadObject(ms);
        return list;
    }
