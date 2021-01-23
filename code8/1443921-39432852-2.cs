    [WebMethod]
    public String InsertFeedBack(YourClass model)
    {
     DataTable dt = detailsBAL.InsertFeedBack(model.name, model.email, model.category, model.message);
     return JsonConvert.SerializeObject(dt);
    } 
