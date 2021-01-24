        private IWebElement ElementEnabled(IWebElement element, int timeout = 1000)
        {
            var s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromMilliseconds(timeout))
            {
                if (element.Enabled)
                {
                    return element;
                }
            }
            s.Stop();
            return null;
        }
