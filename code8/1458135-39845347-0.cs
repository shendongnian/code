     protected void Page_Load(object sender, EventArgs e)
     {
       if (!IsPostBack)
         {
           Session["update"]=Server.UrlEncode(System.DateTime.Now.ToString());
         }
     }
