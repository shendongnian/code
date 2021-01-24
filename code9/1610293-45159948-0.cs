    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["success"] == "true")
        {
            //show success here
            txtSuccess.Visible = true;
        }
        else
        {
            //set success invisible
            txtSuccess.Visible = false;
        }
    }
    
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        var url = Request.RawUrl;
        //check if querystring already present
        if (url.IndexOf('?') == -1) {
            //create a querystring
            Response.Redirect($"{url}?success=true");
        }
        else
        {
            //append to existing querystring parameters
            Response.Redirect($"{url}&success=true");
        }
        
    }
