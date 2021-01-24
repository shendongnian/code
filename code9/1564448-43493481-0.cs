    // Site.Master.cs
    protected void Page_Init(object sender, EventArgs e)
    {
        SiteMap.SiteMapResolve += new SiteMapResolveEventHandler(GenerateSubMenu);
    }
    
    private static bool siteMapModified = false;
    private SiteMapNode GenerateSubMenu(Object sender, SitemapResolveEventArgs e)
    {
        if (!siteMapModified)
        {
            siteMapModified = true;
            var targetNode = SiteMap.RootNode.ChildNodes[3];
            targetNode.ReadOnly = false;
            // create writeable collection
            var childNodes = new SiteMapNodeCollection(targetNode.ChildNodes);
            var statusUrl = VirtualPathUtility.ToAbsolute("~/Content/status.aspx");
            var elements= LoadDynamicElements();
            foreach (var element in elements)
            {
                childNodes.Add(
                    new SiteMapNode(
                        targetNode.Provider, 
                        element, 
                        statusUrl + "?k=" + element, 
                        element));
            }
            targetNode.ChildNodes = childNodes;
        }
        return SiteMap.CurrentNode;
    }
