    [HttpPost]
    [Route("api/BTS_Admin/Login")]
    public HttpResponseMessage AdminLogin(Admin admin)
    {
        Admin response = admin.LoginCheck();
        if (response != null)
        {
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        else
        {
            //ajax get error from here, because you set 404 error (Not found.)
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Login Failed");
        }
    }
