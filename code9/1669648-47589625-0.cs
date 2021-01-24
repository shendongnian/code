    public Task<IHttpActionResult> DeviceLogin(MyDevice device)
    {
        EnummyError myError = EnummyError.None;
        // Authenticate Device.
        myError = this.Authenticate(device);
        if (myError != EnummyError.None)
        {
            return ResponseMessage(Request.CreateResponse(Request.CreateResponse(HttpStatusCode.Forbidden, myError.ToString()));
        }
    }
