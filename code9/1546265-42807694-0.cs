    public async Task<string> MakeRequest()
    {
        var request = WebRequest.Create(url);
        var postStream = await request.GetRequestStreamAsync();
        // Convert the string into a byte array.
        byte[] byteArray = Encoding.UTF8.GetBytes(request.Connection);
        // Write to the request stream.
        postStream.Write(byteArray, 0, request.Connection.Length);
        postStream.Close();
        var response = await (HttpWebResponse)request.GetResponseAsync();
        var streamResponse = response.GetResponseStream();
        using (var streamRead = new StreamReader(streamResponse))
        {
            var responseString = streamRead.ReadToEnd();
            var trimResponseString = responseString.Trim(); // I need this string to return from MakeRequest
            // Close the stream object
            streamResponse.Close();
            streamRead.Close();
            // Release the HttpWebResponse
            response.Close();
            allDone.Set();
            return trimResponseString;
        }
    }
