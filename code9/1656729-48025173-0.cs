    [AttributeUsage(AttributeTargets.Property)]
    public class RestrictUserRoles : Attribute
    {
        public RestrictUserRoles(UserRoles roles)
        {
            Roles = roles;
        }
        public UserRoles Roles { get; }
    }
