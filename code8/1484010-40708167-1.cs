    public string Result()
    {
        var request = (HttpWebRequest)WebRequest.Create("192.168.1.101:8000/mytest");
        var response = request.GetResponse();
        var stream = new StreamReader(response.GetResponseStream());
        var finalResponse = stream.ReadToEnd();
        return finalResponse;
    }
