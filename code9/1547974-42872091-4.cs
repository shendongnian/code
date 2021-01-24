    public class addHost: Form
    {
        public delegate void OnAddHost(string host, string alias)
        public event OnAddHost HostAdded;
        ....
