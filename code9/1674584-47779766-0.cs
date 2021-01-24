    [HttpPost]
    [Route("api/Process")]
    public async Task Process(FormCollection form)
    {
        if (form.AllKeys.Contains("name")) lcName = form["name"].ToString() ?? "";
        ... etc ...
    }
