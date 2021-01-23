    public string Result() // <-- "string" instead of "void"
    {
        var request = (HttpWebRequest)WebRequest.Create("192.168.1.101:8000/mytest");
        using (var response = (HttpWebResponse)request.GetResponse())
        using (var stream = response.GetResponseStream())
        using (var reader = new StreamReader(stream))
        {
            return reader.ReadToEnd(); // <-- return the result
        }
    }
