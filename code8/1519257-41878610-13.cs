    public interface ISessionInfo {
        string Id { set; get; }
        string Email { set; get; }
        string UserName { set; get; }
        UserDetailsViewModel _userDetailsViewModel { set; get; }
        string permission { set; get; }
        
        OrganizationViewModels Organization { set; get; }
        List<UserTeamModels> teams { set; get; }
        string status { set; get; }
        string role { set; get; }
        List<string> roles { set; get; }
    }
    public class SessionInfo : ISessionInfo { ... }
    public interface ISessionAdapterService {
        void Clear();
        void Abandon();
        bool DoesSessionExists { get; }
        ISessionInfo Instance { get; set; } 
    }
