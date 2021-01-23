    public static string GetDataSync(string packageName)
    {
        string result = "";
        Uri uri = new Uri(googlePlayUrl + packageName);
        var request = HttpWebRequest.Create(uri);
        var response = request.GetResponse();
        var responseStream = response.GetResponseStream();
        using (StreamReader reader = new StreamReader(responseStream))
        {
            result = (reader.ReadToEnd());
        }
        responseStream.Close();
        return result;
    }
