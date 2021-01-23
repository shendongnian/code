    private List<string> user = new List<string>();
    public List<string> User
    {
        private get { return user; }
        set
        {
            user = value;
            Notify("user");
        }
    }
