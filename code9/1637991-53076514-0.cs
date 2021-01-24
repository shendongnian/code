    using CefSharp;
    using CefSharp.MinimalExample.WinForms.Controls;
    using CefSharp.WinForms;
    using System.Collections.Generic;
    using System.Windows.Forms;
    namespace FullScreen
    {
        public class DisplayHandler : IDisplayHandler
        {
            private Control parent;
            private Form fullScreenForm;
            void IDisplayHandler.OnAddressChanged(IWebBrowser browserControl, AddressChangedEventArgs addressChangedArgs)
            {
            }
            void IDisplayHandler.OnTitleChanged(IWebBrowser browserControl, TitleChangedEventArgs titleChangedArgs)
            {
            }
            void IDisplayHandler.OnFaviconUrlChange(IWebBrowser browserControl, IBrowser browser, IList<string> urls)
            {
            }
            void IDisplayHandler.OnFullscreenModeChange(IWebBrowser browserControl, IBrowser browser, bool fullscreen)
            {
                var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;
                chromiumWebBrowser.InvokeOnUiThreadIfRequired(() =>
                {
                    if (fullscreen)
                    {
                        parent = chromiumWebBrowser.Parent;
                        parent.Controls.Remove(chromiumWebBrowser);
                        fullScreenForm = new Form();
                        fullScreenForm.FormBorderStyle = FormBorderStyle.None;
                        fullScreenForm.WindowState = FormWindowState.Maximized;
                        fullScreenForm.Controls.Add(chromiumWebBrowser);
                        fullScreenForm.ShowDialog(parent.FindForm());
                    }
                    else
                    {
                        fullScreenForm.Controls.Remove(chromiumWebBrowser);
                        parent.Controls.Add(chromiumWebBrowser);
                        fullScreenForm.Close();
                        fullScreenForm.Dispose();
                        fullScreenForm = null;
                    }
                });
            }
            bool IDisplayHandler.OnTooltipChanged(IWebBrowser browserControl, string text)
            {
                return false;
            }
            void IDisplayHandler.OnStatusMessage(IWebBrowser browserControl, StatusMessageEventArgs statusMessageArgs)
            {
            }
            bool IDisplayHandler.OnConsoleMessage(IWebBrowser browserControl, ConsoleMessageEventArgs consoleMessageArgs)
            {
                return false;
            }
        }
    }
