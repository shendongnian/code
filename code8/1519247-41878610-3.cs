    public class SessionAdapterService : ISessionAdapterService {
        public string DisplayName { 
            get { return SessionAdapter.Instance._userDetailsViewModel.display_name; } 
            set { SessionAdapter.Instance._userDetailsViewModel.display_name = value; } 
        }
        public int Id {
            get { return SessionAdapter.Instance._userDetailsViewModel.id; }
        }
    }
