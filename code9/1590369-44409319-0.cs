        public bool AddControlsClicked
        {
            get
            {
                return Convert.ToBoolean(ViewState["AddControlsClicked"]);
            }
            set
            {
                ViewState["AddControlsClicked"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(AddControlsClicked)
            {
                for (int i = 0; i < 5; i++)
                {
                    LinkButton deleteDomain = new LinkButton();
                    deleteDomain.Text = "Delete";
                    deleteDomain.Click += new System.EventHandler(deleteDomain_Click);
                    //deleteDomain.ClientIDMode = ClientIDMode.Static;
                    //deleteDomain.CommandArgument = item.Text;
                    divEditDomainName.Controls.Add(deleteDomain);
                }
            }
        }
        void deleteDomain_Click(object sender, EventArgs e)
        {
            //Some Code;
        }
        protected void AddControls_Click(object sender, EventArgs e)
        {
            AddControlsClicked = true;
            Page_Load(sender, e);
        }
