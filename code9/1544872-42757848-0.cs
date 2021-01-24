    private void show(string message)
    {
        System.Web.UI.Page page = this.Page;
        ScriptManager.RegisterStartupScript(page, page.GetType(), "popup", "alert('" + message + "');", true);
    }
