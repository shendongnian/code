    var client = new RestClient(apiUrl);
    client.Authenticator = new HttpBasicAuthenticator(username + "/token", token);
    client.AddDefaultHeader("Accept", "application/json");
    string name = "name";
    byte[] data; //Read all bytes of file
    string filename = "filename.jpg";
    var request = new RestRequest("/uploads.json", Method.POST);
    request.AddFile(name, data, filename, "application/binary");
    request.AddQueryParameter("filename", filename);
    var response = _zendeskClient.Execute(request);
