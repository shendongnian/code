        private IWebElement FindElementById(string id, int timeout = 1000)
        {
            IWebElement element = null;
            var s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromMilliseconds(timeout))
            {
                try
                {
                    element = _driver.FindElementById(id);
                    break;
                }
                catch (NoSuchElementException)
                {
                }
            }
            s.Stop();
            return element;
        }
