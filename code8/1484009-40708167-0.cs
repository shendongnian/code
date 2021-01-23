    public string Result()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("192.168.1.101:8000/mytest");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader stream = new StreamReader(response.GetResponseStream());
        string FinalResponse = stream.ReadToEnd();
        //Console.WriteLine(FinalResponse);
        return FinalResponse;
    }
    
