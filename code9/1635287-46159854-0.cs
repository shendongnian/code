    [System.Web.Http.Route("api/wdretrievedata")]
    [System.Web.Http.HttpGet]
    public async Task<IHttpActionResult> RetrieveUserData(string email)
    {
        var user =  await new WDUserData();
        user.FirstName = "FirstName";
        user.LastName="LastName";
        user.PhoneNumber="PhoneNumber";
        return Ok(user);
    }
