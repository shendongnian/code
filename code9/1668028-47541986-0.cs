    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    public partial class Index : System.Web.UI.Page
    {
        public static class RGX
        {
            public static Regex regex = new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", RegexOptions.Singleline, TimeSpan.FromSeconds(5));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.DataBind();
        }
    }
