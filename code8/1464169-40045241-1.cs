    public partial class myClass : Other.Class
    {
        long check1parameter = CurrentSession.CurrentFile.ID;
        protected override void EnquiryLoaded(object sender, System.EventArgs e)
        {
            disableFields();
        }
        private void disableFields()
        {
            if (checkEverything)
            {
                EnquiryForm.GetControl("Status").Enabled = true;
            }
        }
        // the parameter name was the same as a variable in the class
        // renamed to avoid confusion
        public bool check1_method
        {
            get {return check1parameter.ToString().Contains("something");}
        }
        public bool checkEverything
        {
            get { return CurrentSession.CurrentUser.IsInRoles("RequiredRole") 
                && check1_method; }
        }
        //other methods
    }
