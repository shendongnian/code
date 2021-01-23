    public partial class myClass : Other.Class
        {
            long check1parameter = CurrentSession.CurrentFile.ID;
            protected override void EnquiryLoaded(object sender, System.EventArgs e) 
            {
                disableFields();
            }
            private void disableFields() 
            {
                EnquiryForm.GetControl("Status").Enabled = checkEverything();
            }
            public bool check1_method(long check1parameter) {
                return check1parameter.ToString().Contains("something");
            }
            public bool checkEverything() {
                bool roleCheck = CurrentSession.CurrentUser.IsInRoles("RequiredRole");
                bool check1 = check1_method(check1parameter);
                return (roleCheck && check1);
            }
            //other methods
        }
