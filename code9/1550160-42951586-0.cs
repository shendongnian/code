    int errorCode = 9999;         
    if (isReroute) {
      this.Response.StatusCode = errorCode;
      Response.RedirectToRoute("Login");
      throw new System.Web.Http.HttpResponseException(
          new HttpResponseMessage(HttpStatusCode.ExpectationFailed));
    }
