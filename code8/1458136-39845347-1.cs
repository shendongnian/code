    protected void btnSubmit_Click(object sender, EventArgs e)
    {
         if (Session["update"].ToString() == ViewState["update"].ToString())
          {
             try
             {
              -----------Your Logic
             }
             finally
             {
              Session["update"]=Server.UrlEncode(System.DateTime.Now.ToString());
             }
          }
    }
