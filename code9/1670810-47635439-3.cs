    public interface IUserAccessHelper
    {
        bool IsInRole(string role);
    }
    public class UserAccessHelper : IUserAccessHelper
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public UserAccessHelper(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public Boolean IsInRole(string role)
        {
            Boolean roleMembership = false;
            if (httpContextAccessor.HttpContext.Session.GetInt32("ID") != null)
            {
                if (httpContextAccessor.HttpContext.Session.GetString("Role") == role)
                {
                    roleMembership = true;
                }
            }
            return roleMembership;
        }
    }
