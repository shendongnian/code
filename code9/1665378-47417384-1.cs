    private string GetToken(string username, string password, string tenancyName = null)
    {
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(
            "http://localhost:6334/api/Account/Authenticate");
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "POST";
        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            var input = "{\"usernameOrEmailAddress\":\"" + username + "\"," +
                        "\"password\":\"" + password + "\"}";
            if (tenancyName != null)
            {
                input = input.TrimEnd('}') + "," +
                        "\"tenancyName\":\"" + tenancyName + "\"}";
            }
            streamWriter.Write(input);
            streamWriter.Flush();
            streamWriter.Close();
        }
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        string response;
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            response = streamReader.ReadToEnd();
        }
        // Crude way
        var entries = response.TrimStart('{').TrimEnd('}').Replace("\"", String.Empty).Split(',');
        foreach (var entry in entries)
        {
            if (entry.Split(':')[0] == "result")
            {
                return entry.Split(':')[1];
            }
        }
        return null;
    }
