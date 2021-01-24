    public async Task<IHttpActionResult> send()
    {
        var path = HttpContext.Current.Server.MapPath("~/uploads");
        var provider = new MultipartFormDataStreamProvider(root);
        var result = await Request.Content.ReadAsMultipartAsync(provider);
        var modelFromClient = result.FormData["model"];
        var clientModel = JsonConvert.Deserialize<Model>(modelFromClient);
        return await add(clientModel.user);
    }
    public async Task<IHttpActionResult> add(User user)
    {
        //Do whatever you need with user
        
        //Save the object in database
        user.Save();
    }
