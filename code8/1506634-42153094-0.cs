    public static void RemoveTaskPaneExt(WordprocessingDocument package)
        {
            WebExTaskpanesPart webExTaskpanesPart1 = package.GetPartsOfType<WebExTaskpanesPart>().FirstOrDefault();
    
            if (webExTaskpanesPart1 != null)
            {
                WebExtensionPart aWebExtension =
                    webExTaskpanesPart1.GetPartsOfType<WebExtensionPart>()
                        .Where(
                            x =>
                                x.WebExtension.WebExtensionStoreReference.Id ==
                                System.Configuration.ConfigurationManager.AppSettings["PaneID"])
                        .FirstOrDefault();
                if (aWebExtension != null)
                {
    webExTaskpanesPart1.Taskpanes.RemoveAllChildren();
                    bool result = package.WebExTaskpanesPart.DeletePart(aWebExtension);
                }                
            }
    }
