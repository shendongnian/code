    protected void Application_Start(object sender, EventArgs e)
    {
        string jqversion = "1.12.4"; // match this to available jQuery version you have
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
        {
            Path = "~/Scripts/jquery-" + jqversion + ".min.js",
            DebugPath = "~/Scripts/jquery-" + jqversion + ".js",
            CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + jqversion + ".min.js",
            CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + jqversion + ".js",
            CdnSupportsSecureConnection = true,
            LoadSuccessExpression = "window.jQuery"
        });
    }
