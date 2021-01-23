    using DotNetBrowser;
    using DotNetBrowser.Events;
    using DotNetBrowser.WPF;
    using System;
    using System.Drawing.Imaging;
    using System.Threading;
    using System.Windows;
    
    namespace HTMLToImageSample
    {
        public partial class WindowMain : Window
        {
            private WPFBrowserView browserView;
    
            public WindowMain()
            {
                this.Loaded += delegate
                {
                    Width = 400;
                    Height = 300;
    
                    browserView = new WPFBrowserView(BrowserFactory.Create(BrowserType.LIGHTWEIGHT));
                    Browser browser = browserView.Browser;
    
    
                    // #1 Set browser initial size
                    browserView.Browser.SetSize(1280, 1024);
    
                    // #2 Load web page and wait until web page is loaded completely.
                    ManualResetEvent resetEvent = new ManualResetEvent(false);
                    FinishLoadingFrameHandler listener = new FinishLoadingFrameHandler((object sender, FinishLoadingEventArgs e) =>
                    {
                        if (e.IsMainFrame)
                        {
                            resetEvent.Set();
                        }
                    });
                    browser.FinishLoadingFrameEvent += listener;
                    try
                    {
                        browser.LoadURL("teamdev.com/dotnetbrowser");
                        resetEvent.WaitOne(new TimeSpan(0, 0, 45));
                    }
                    finally
                    {
                        browser.FinishLoadingFrameEvent -= listener;
                    }
    
    
                    // #3 Set the required document size.
                    JSValue documentHeight = browserView.Browser.ExecuteJavaScriptAndReturnValue(
                            "Math.max(document.body.scrollHeight, " +
                            "document.documentElement.scrollHeight, document.body.offsetHeight, " +
                            "document.documentElement.offsetHeight, document.body.clientHeight, " +
                            "document.documentElement.clientHeight);");
                    JSValue documentWidth = browserView.Browser.ExecuteJavaScriptAndReturnValue(
                            "Math.max(document.body.scrollWidth, " +
                            "document.documentElement.scrollWidth, document.body.offsetWidth, " +
                            "document.documentElement.offsetWidth, document.body.clientWidth, " +
                            "document.documentElement.clientWidth);");
    
                    int scrollBarSize = 25;
    
                    int viewWidth = (int)documentWidth.GetNumber() + scrollBarSize;
                    int viewHeight = (int)documentHeight.GetNumber() + scrollBarSize;
    
                    // #4 Register OnRepaint to get notifications
                    // about paint events. We expect that web page will be completely rendered twice:
                    // 1. When its size is updated.
                    // 2. When HTML content is loaded and displayed.
                    ManualResetEvent waitEvent = new ManualResetEvent(false);
                    DrawingView drawingView = (DrawingView)browserView.GetInnerView();
                    drawingView.OnRepaint += delegate(object sender, OnRepaintEventArgs e)
                    {
                        // Make sure that all view content has been repainted.
                        if (e.UpdatedRect.Size.Equals(e.ClientSize))
                        {
                            waitEvent.Set();
                        }
                    };
                    browserView.Browser.SetSize(viewWidth, viewHeight);
                    // #5 Wait until Chromium renders web page content.
                    waitEvent.WaitOne();
                    // #6 Save Image of the loaded web page into a PNG file.
                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        browserView.GetImage().Save(@"teamdev.png", ImageFormat.Png);
                    }));
                };
            }
    
            [STAThread]
            public static void Main()
            {
                Application app = new Application();
    
                WindowMain wnd = new WindowMain();
    
                app.Run(wnd);
    
                var browser = wnd.browserView.Browser;
                wnd.browserView.Dispose();
                browser.Dispose();
            }
        }
    
    }
