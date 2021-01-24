    [HttpPost]
    public IHttpActionResult GenerateToken([FromBody] AuthModel model) {
        string userName = model.userName;
        string password = model.password;
        //...
    }
