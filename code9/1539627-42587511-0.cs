    @{ 
        Layout = "~/Views/Shared/_Layout.cshtml";
        string[] roles = BusinessLayer.BLGetUserRoles(User.Identity.Name).ToArray();
        GenericPrincipal principal = new GenericPrincipal(User.Identity, roles);
        Thread.CurrentPrincipal = System.Web.HttpContext.Current.User = principal;
    }
