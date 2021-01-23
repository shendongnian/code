    private List<string> users = new List<string>();
    public List<string> Users
    {
        private get { return users; }
        set
        {
            user = value;
            Notify("user");
        }
    }
