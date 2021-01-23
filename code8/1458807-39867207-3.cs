        public string foobar;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["foo"] != null)
            {
                foobar = Request.QueryString["foo"];
                if (foobar == "CourseID")
                {
                    StandardID.Visible = false;
                    CourseID.Visible = true;
                }
                else
                {
                    StandardID.Visible = true;
                    CourseID.Visible = false;
                }
            }
        }
