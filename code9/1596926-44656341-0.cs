    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
         private Role roleEnum;
         public Role RoleEnum
         {
             get { return roleEnum; }
             set { roleEnum = value; base.Roles = value.ToString(); }
         }
    }
