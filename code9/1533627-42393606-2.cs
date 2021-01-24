    [HttpPost]
    [Route("Clientes")]
    public HttpResponseMessage GetClientes([FromBody]WebAuthModel model)
    {
        SetUser(model);
        return Response(db.MyEntities.ToList().Select(x => GenericCreator.GetModel(x)));
    }
