        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> mylist = new List<string>();
                mylist.Add("Option 1");
                mylist.Add("Option 2");
                mylist.Add("Option 3");
                lbx_Marked.DataSource = mylist;
                lbx_Marked.DataBind();
            }
        } 
