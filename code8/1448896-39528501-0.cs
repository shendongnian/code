    public HttpResponseMessage Post([FromBody]dynamic value)
    {
        int id= value.id.ToString();
        string name = value.name.ToString();
    }
