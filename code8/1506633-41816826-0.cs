    private static void RemoveWebExtensionPart(WordprocessingDocument package)
        {
            WebExTaskpanesPart webExTaskpanesPart1 = package.GetPartsOfType<WebExTaskpanesPart>().FirstOrDefault();
            if (webExTaskpanesPart1 != null)
            {
                bool result2 = package.DeletePart(webExTaskpanesPart1);
            }
        }
