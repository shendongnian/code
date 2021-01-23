    public string Result() // <-- "string" instead of "void"
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("192.168.1.101:8000/mytest");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader stream = new StreamReader(response.GetResponseStream());
        string FinalResponse = stream.ReadToEnd();
        return FinalResponse; // <-- return the result
    }
