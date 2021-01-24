           protected void Page_Load(object sender, EventArgs e)
            {
        
            }
        
            protected void txtInstructions_TextChanged(object sender, EventArgs e)
            {
                StrautoDoc.Text = DateTime.Now.ToString("MM/dd/yy") + " - " + GetUserName() + " assigned " + txtInstructions.Text + " to  [person being assigned the task]";
            }
        
            private string GetUserName()
            {
               return "name";
            }
