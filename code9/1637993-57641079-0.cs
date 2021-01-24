csharp
using CefSharp;
using CefSharp.WinForms;
using System.Windows.Forms;
namespace WatchNow
{
    public class KeyboardHandler : IKeyboardHandler
    {
        public bool OnKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey)
        {
            return false;
        }
        public bool OnPreKeyEvent(IWebBrowser browserControl, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey, ref bool isKeyboardShortcut)
        {
            var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;
            if ((Keys)windowsKeyCode == Keys.Escape)
            {
                chromiumWebBrowser.Invoke((MethodInvoker)delegate 
                {
                    bool fullScreen = Screen.FromControl(chromiumWebBrowser).Bounds.Size == chromiumWebBrowser.Size;
                    if (fullScreen)
                    {
                        chromiumWebBrowser.DisplayHandler.OnFullscreenModeChange(browserControl, browser, false);
                    }
                });
            }
            
            return false;
        }
    }
}
