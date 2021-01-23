    public class authoritiesInfo
    {
        public string Name { get; set; }
        public List<string> Values { get; set; }
    }
    public class dashboardModel
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public List<authoritiesInfo> auth { get; set; }
    }
