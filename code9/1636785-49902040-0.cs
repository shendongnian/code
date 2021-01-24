    [HttpPatch]
    [Consumes(JsonMergePatchDocument.ContentType)]
    public void Patch([FromBody] JsonMergePatchDocument<Model> patch)
    {
        ...
        patch.ApplyTo(backendModel);
        ...
    }
