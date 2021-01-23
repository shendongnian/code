    @using Microsoft.AspNet.Identity;
    var authenticateResult = await HttpContext.GetOwinContext()
                                   .Authentication.AuthenticateAsync(
                                       DefaultAuthenticationTypes.ApplicationCookie
                                   );
    var isPersistent = authenticateResult.Properties.IsPersistent; //// true or false
