    public static class ExtensionHelper
    {
        public static string UserIdentity(this Controller controller)
        {
            return controller.HttpContext.User.Identity.Name.Split('\\')[1].Replace(".", " ");
        }
    }
