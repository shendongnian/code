    HttpClient client = new HttpClient();
    var byteArray = Encoding.ASCII.GetBytes("username:password");
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
    HttpResponseMessage response = await client.GetAsync("http://CAMERA-IP/cgi-bin/snapshot.cgi?channel=0");
    byte[] myBytes = await response.Content.ReadAsByteArrayAsync();
    string convertedFromString = Convert.ToBase64String(myBytes);
    return "data:image/png;base64," + convertedFromString;
