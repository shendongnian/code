    [System.Web.Services.WebMethod]
    public static string RequestControlString()
    {
        TextWriter stringWriter = new StringWriter();
        HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
        var dt = new List<string>() { "1", "2", "3", "4" };
        var gridview = new GridView() { DataSource = dt };
        // you can replace this button to usercontrol or repeater. 
        // i recommend usercontrol.
        // because you have a style.
        gridview.DataBind();
        gridview.RenderControl(htmlWriter);
        string html = stringWriter.ToString();
        return html;
    }
