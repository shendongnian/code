    public abstract class PageBase : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            if (Session["username"] == null & Session["role"] == null)
                {
                    Response.Redirect("WebLogin.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
