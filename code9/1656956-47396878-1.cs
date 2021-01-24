    using System.Diagnostics;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load()
        {
            var applicationPath = "\\\\cmbfs02\\Software\\web\\EmailSignature_WPF\\EmailSignature_WPF.exe";
            Process.Start(applicationPath);
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        }
    }
