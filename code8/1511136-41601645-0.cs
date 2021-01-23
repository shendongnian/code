    protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    lit1.Text += "<ul>" + "<li \' onclick=\'javascript: __doPostBack(\"getProduct\", \"1\");\'>"
                                 + "Product " + "1"
                                 + "</li>"
                                 + "</ul>";
                }
                if (Request.Form["__EVENTTARGET"] != null && Request.Form["__EVENTTARGET"] == "getProduct")
                {
                    getProduct_Click(null, null);
                }
            }
    
            private void getProduct_Click(object sender, System.EventArgs e)
            {
                Response.Write("You Clicked on " + Request.Form["__EVENTARGUMENT"]);
            }
