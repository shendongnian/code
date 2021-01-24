    protected void btnHome_Click(object sender, EventArgs e)
    {
        var h1 = new HtmlGenericControl("h1") {InnerText = "Home"};
        contentArea.Controls.Add(h1);
    
        var p = new HtmlGenericControl("p") {InnerText = "Home Elements here"};
        contentArea.Controls.Add(p);
    }
    
    protected void btnProducts_Click(object sender, EventArgs e)
    {
        var h1 = new HtmlGenericControl("h1") {InnerText = "Products"};
        contentArea.Controls.Add(h1);
    
        var p = new HtmlGenericControl("p") {InnerText = "Products Elements here"};
        contentArea.Controls.Add(p);
    
        var lnkMicrosoft = new HyperLink
        {
            Text = "Go to Microsoft",
            NavigateUrl = "http://www.microsoft.com"
        };
        contentArea.Controls.Add(lnkMicrosoft);
    
        var lnkGoogle = new HyperLink
        {
            Text = "Go to Google",
            NavigateUrl = "http://www.google.com"
        };
        contentArea.Controls.Add(lnkGoogle);
    }
