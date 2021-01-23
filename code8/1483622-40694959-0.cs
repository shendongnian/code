    public long SomeMethod(string url)
    {
        var request = (HttpWebRequest)WebRequest.Create(url);
        var response = request.GetResponse();
        return response.ContentLength;
    }
