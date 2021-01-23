    public  class SessionInfo
    {
        public virtual string Id { set; get; }
        public virtual string Email { set; get; }
        public virtual string UserName { set; get; }
        public virtual UserDetailsViewModel _userDetailsViewModel { set; get; }
        public virtual string permission { set; get; }
        
        public virtual OrganizationViewModels Organization { set; get; }
        public virtual List<UserTeamModels> teams { set; get; }
        public virtual string status { set; get; }
        public virtual string role { set; get; }
        public virtual List<string> roles { set; get; }
    }
