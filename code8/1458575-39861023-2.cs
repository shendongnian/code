    public static class MyExtensions
    {
        public static Task NavigateAsync(this WebBrowser browser, Uri  uri)
        {
            var tcs = new TaskCompletionSource<object>();
            LoadCompletedEventHandler loadCompleted = null;
            loadCompleted = (s, e) =>
            {
                browser.LoadCompleted -= loadCompleted;
                tcs.SetResult(e.WebResponse);
            };
            browser.LoadCompleted += loadCompleted;
            browser.Navigate(uri);
            return tcs.Task;
        }
    }
