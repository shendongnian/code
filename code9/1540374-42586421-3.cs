        public partial class foo: Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void BtnSubmit(object sender, EventArgs e)
            {
                if (Page.IsValid)
                {
                    //Do what you need to do only if IsValid which is the server-side validation check
                }
            }
        }
