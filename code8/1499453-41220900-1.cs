    public ActionResult DownloadIndex(int id)
    {
        try
        {
            string Filelocation = "MyServerLocationFolder";
            OnePossModel md = new Models.OnePossModel();
            JsonParamBuilder myBuilder = new JsonParamBuilder();
            myBuilder.AddParam<Guid>("userid", System.Guid.Parse(User.Identity.GetUserId()));
            myBuilder.AddParam<int>("id", Convert.ToInt32(id));
    
            string jsonReq = Models.JsonWrapper.JsonPOST(ApiBaseUrl +  "/WriteFile", myBuilder.GetJSonParam());
            string poassFilename = Models.DeserialiseFromJson<string>.DeserialiseApiResponse(jsonReq);
    
            string filepath = Filelocation + poassFilename.ToString();
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
           
            return File(filedata, "text/plain", Server.UrlEncode(poassFilename)); 
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
