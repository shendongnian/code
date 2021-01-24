    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Diagnostics;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                Process process = new Process();            
                process.StartInfo.FileName = "echo.exe";            
                process.Start();            
        }
    }
