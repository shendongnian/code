    [Route("Authentificate")]
    public IHttpActionResult GetUserAuthenticated([FromBody]AuthenticateViewModel model){
         var userName = model.Username;
         var pwd = model.Password;
    }
