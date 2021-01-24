        protected void Page_Load(object sender, EventArgs e)
        {
            var menu = new List<string>();
            menu.Add("Action");
            menu.Add("Another action");
            menu.Add("Something else here");
            LoadMenuByAddingChildControls(menu);
        }
