    string getStatus = "checked";
            bool s = false;
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
            protected void OnChangeEvent(object sender, EventArgs e)
            {
                getStatus = CheckBox1.Checked == true ? "checked" : "unchecked";
                checkbool();
            }
           
        protected bool checkbool()
        {
            return s = getStatus == "checked" ? true : false;
        }
