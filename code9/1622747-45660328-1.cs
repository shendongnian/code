    public class CheckAttendeeNameAttribute : System.Web.DomainServices.AuthorizationAttribute
    {    
        public override bool Authorize(System.Security.Principal.IPrincipal principal)
        {
            if (principal.IsInRole("Attendee") && principal.Identity.Name.StartsWith("A"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
