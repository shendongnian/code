    using System;
    
    namespace WebApplication1
    {
        public partial class Default : System.Web.UI.Page
        {
            private static string filePath = @"C:\Uploads\";
            protected void Page_Load(object sender, EventArgs e)
            {
            }
    
            protected void btnSendEmail_Click(object sender, EventArgs e)
            {
                Sender mailSender = new Sender();
                mailSender.SendEmail("myfirstemail@gmail.com", "mysecondemail@gmail.com", "Async mail with attachment", "Async mail with attachment body goes here ...", filePath + "TestFile.txt");
                Response.Redirect("Success.aspx", false);
            }
        }
    }
