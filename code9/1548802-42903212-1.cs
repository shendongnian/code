    using System;
    
    namespace StackoverflowWebForm
    {
        public partial class Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void btnAdd_Click(object sender, EventArgs e)
            {
                txtResult.Text = hidConfirmValue.Value;
            }
        }
    }
