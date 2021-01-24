        public static string MyVar;
        protected void Page_Load(object sender, EventArgs e)
        {
       
        if (!string.IsNullOrWhiteSpace(MyVar))
        {
            varcheck(MyVar);
        }
    }
