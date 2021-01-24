        public int WaitToLoad(By by)
        {
            int i = 0;
            while (i < 600)
            {
                i++;
                Thread.Sleep(100); // sleep 100 ms
                try
                {
                    driver.FindElement(by);
                    break;
                }
                catch { }
            }
 		    return i; // page load latency in 1/10 secs
        }
