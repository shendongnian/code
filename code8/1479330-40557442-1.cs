    using (IBPC_DevEntities entity = new IBPC_DevEntities())
    {
        entity.Configuration.LazyLoadingEnabled = false;
        return Request.CreateResponse(HttpStatusCode.OK,
            entity.User.FirstOrDefault(u => u.NDBHUserID == id));
    }
