    public partial class Page1 {
    
        UserPrincipal _loggedOnUser;
    
        public void Page_Load() {
            var context = new PrincipalContext(ContextType.Domain, "dc", "DC=domain,DC=com", "user", "password");
            _loggedOnUser= UserPrincipal.FindByIdentity(context, User.Identity.Name);
            string Name = _loggedOnUser.Name.Trim();
            lblName.Text = Name;
        }
    
    }
