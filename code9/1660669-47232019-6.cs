        protected override void OnInit(EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Request.Params["__EVENTTARGET"]))
                return;
            var controlName = Request.Params["__EVENTTARGET"];
            if (controlName != "btnShowDeptsUserControl")
                return;
            LoadSomeData();  // call method to load the user control
            this.Visible = true;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // empty
        }
        private void LoadSomeData()
        {
            // get data from database
            // load table / gridview / etc
            // make service call
        }
        protected void btnEmailDepts_Click(object sender, EventArgs e)
        {
            EmailDepts();  // this event is now executed when the button is clicked
        }
        private void EmailDepts()
        {
            // do something
        }
