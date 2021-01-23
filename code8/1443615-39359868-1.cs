    using System;
    using System.Security.Principal;
    using System.Web.Security;
    
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PopulateCurrentUserName();
        }
    
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie("test_user", false);
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    
        private void PopulateCurrentUserName()
        {
            IPrincipal user = Request.RequestContext.HttpContext.User;
            if (user != null && user.Identity != null && !String.IsNullOrEmpty(user.Identity.Name))
                CurrentUserLabel.Text = user.Identity.Name;
            else
                CurrentUserLabel.Text = "(null)";
        }
    }
