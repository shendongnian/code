    public async Task<IHttpActionResult> DeviceLogin(MyDevice device)
    {
        EnummyError myError = EnummyError.None;
        // Authenticate Device.
        myError = this.Authenticate(device);
        // Perhaps Authenticate has an async method like this.
        // myError = await this.AuthenticateAsync(device);
        if (myError != EnummyError.None)
        {
            return ResponseMessage(Request.CreateResponse(Request.CreateResponse(HttpStatusCode.Forbidden, myError.ToString()));
        }
    }
