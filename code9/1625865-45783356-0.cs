    [HttpPost]
    [Route("api/user/insert")]
    public HttpResponseMessage insertVehiclesDevice(modelUser user)
    {
      //stuff
      return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
    }
