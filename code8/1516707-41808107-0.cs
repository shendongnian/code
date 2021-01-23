MenuHandler.cs
    internal class MenuHandler : IContextMenuHandler
    {
    	private const int SaveImage = 26503;
    	private const int OpenLinkNewTab = 26501;
    	
    	public event EventHandler OnSaveImage = delegate { };
    
    	void IContextMenuHandler.OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
    	{
    		if(parameters.TypeFlags.HasFlag(ContextMenuType.Media) && parameters.HasImageContents)
    		{
    			model.AddItem((CefMenuCommand)SaveImage, "Save image");
    		}
    		if(!string.IsNullOrEmpty(parameters.UnfilteredLinkUrl))
    		{
    			model.AddItem((CefMenuCommand)OpenLinkNewTab, "Open link in new tab");
    		}
    	}
    
    	 bool  IContextMenuHandler.OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
    	 {
    		return false;
    	 }
    
    	void IContextMenuHandler.OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
    	{
    		if ((int)commandId == SaveImage)
    		{
    			OnSaveImage?.Invoke(this, new ImageSaveEventArgs(parameters.SourceUrl)); //ImageSaveEventArgs is just a class with one property that houses the source url of the image to download.
    		}
    	}
    
    	bool IContextMenuHandler.RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
    	{
    		return false;
    	}
    }
