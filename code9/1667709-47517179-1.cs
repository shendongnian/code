    [HttpGet]
    [AllowAnonymous]
    //[DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.Host)]
    //[ValidateAntiForgeryToken]
    public IHttpActionResult DbTablesCreate() {
        var result = new {  P1 = "test1", P2 = "test2" } ;
        try {
            //...code removed for brevity
        } catch (Exception ex) {
            return Content(HttpStatusCode.BadRequest, result);
        }
        return OK(result);
    }
