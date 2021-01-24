    internal class MenuHandler : IContextMenuHandler
    {
        private const int Copy = 26503;
        void IContextMenuHandler.OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            //Add new custom menu items
            model.AddItem((CefMenuCommand)Copy, "Copy Link Address");
        }
        bool IContextMenuHandler.OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            if ((int)commandId == Copy)
            {
                //using System.Windows.Forms;
                Clipboard.SetText(parameters.SourceUrl);
            }
            return false;
        }
        void IContextMenuHandler.OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
        }
        bool IContextMenuHandler.RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }
