    public string uploadImage(string path, string id_product)
    {
        var client = new RestClient("http://mywebsite.com/api");
        byte[] file = System.IO.File.ReadAllBytes(path);
        var request = new RestRequest("images/products/" + id_product + "?ws_key=" + API_KEY, Method.POST);
        request.AddFileBytes("image", file, Path.GetFileName(path));
        IRestResponse response = client.Execute(request);
        string content = response.Content;
        
        return content;
    }
