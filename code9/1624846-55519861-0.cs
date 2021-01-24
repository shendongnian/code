	private static bool IsRegistered = false;
	//...
    public static System.Web.IHtmlString RenderJS(params string[] paths) {
    	if (!IsRegistered)
    		RegisterBundles();
    	return Scripts.Render(paths);
    }
