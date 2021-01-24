    public static class ViewUserExtensions {
        
        public static User ToCustom(this IPrincipal principal)
        {
            return principal as User;
        }
    }
    <button type="button" visible="@User.ToCustom().IsAdministrator" id="btn"></button>
