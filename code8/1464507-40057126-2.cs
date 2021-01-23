    using System;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Windows.Forms;
    public class BrowserBasedWebScraper
    {
        public static Task<string> LoadUrl(string url)
        {
            var tcs = new TaskCompletionSource<string>();
            Thread thread = new Thread(() => {
                try {
                    Func<string> f = () => {
                        using (WebBrowser browser = new WebBrowser())
                        {
                            browser.ScriptErrorsSuppressed = true;
                            browser.Navigate(url);
                            while (browser.ReadyState != WebBrowserReadyState.Complete)
                            {
                                System.Windows.Forms.Application.DoEvents();
                            }
                            return browser.DocumentText;
                        }
                    };
                    tcs.SetResult(f());
                }
                catch (Exception e) {
                    tcs.SetException(e);
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
            return tcs.Task;
        }
    }
