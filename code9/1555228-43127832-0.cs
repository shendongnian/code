    public class CustomPage : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            CallTOTheDesiredFunction();  //this is the call to the function I want
            base.OnLoad(e);
        }
    } 
