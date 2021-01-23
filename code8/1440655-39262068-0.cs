    public string GenerateActionLink(string id, int logicstatusId)
    {
        var actionName = "Advanced";
        var controllerName = "HighAdvanced";
        if (logicstatusId == 5)
        {
            actionName = "Basic";
            controllerName = "HighBasic";
        }
        var targetUrl = UrlHelper.GenerateUrl("Default", actionName, controllerName, new RouteValueDictionary(new { id = id }), RouteTable.Routes, Request.RequestContext, false);
        return targetUrl;            
    }
