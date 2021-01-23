    if(result == true) {
        obj.UserRole = (from c in entityObject.NCT_UserRegistration where obj.User_Name == c.User_Name && obj.User_Password == c.User_Password select c.User_Role).FirstOrDefault();
        obj.Success = 0;
        obj.User_Password = "";
        var response = Request.CreateResponse(HttpStatusCode.OK, obj);
        
        var newSessionId = new SessionIDManager().CreateSessionID(HttpContext.Current);
        var cookie = new CookieHeaderValue("session-id", newSessionId);
        cookie.Expires = DateTimeOffset.Now.AddDays(1);
        cookie.Domain = Request.RequestUri.Host;
        cookie.Path = "/";
        response.Headers.AddCookies(new[] { cookie });
        
        return ResponseMessage(response);
    }
