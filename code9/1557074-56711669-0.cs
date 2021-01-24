        public bool WaitToLoad(By by)
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
            if (i == 600) return false;
            else return true;
        }
