    <%@ Application Language="C#" %>
    <%@ Import Namespace="System.Security.Principal" %>
    <%@ Import Namespace="System.Threading" %>
    <script runat="server">
    void Application_OnPostAuthenticateRequest(object sender, EventArgs e) {
      HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
      if (authCookie == null || authCookie.Value == "") return;
      FormsAuthenticationTicket authTicket;
      try {
        authTicket = FormsAuthentication.Decrypt(authCookie.Value);
      } catch {
        return;
      }
  
      // retrieve roles from UserData
      string[] roles = authTicket.UserData.Split('|');
      if (Context.User != null) Context.User = new GenericPrincipal(Context.User.Identity, roles);
    }
    </script>
