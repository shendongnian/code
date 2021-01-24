            private Thread thr = null;
            public void test1()
            {
                var dr = new chromdriver();
                dr.navigate().GoToUrl("http://google.com");
                if(xx != null)
                {
                    IWebElement emal = dr.FindElement(By.XPath("//[@id=\"Email\"]"));
                    emal.Sendkeys(email);
                }
                else
                {
                    IWebElement emal = dr.FindElement(By.XPath("//[@id=\"Email\"]"));
                    emal.Sendkeys(email);
                }
            }
            private void button2_Click(object sender, EventArgs e)
            {
               thr = new Thread(test1);
               thr.Start();
            }
            private void button3_Click(object sender, EventArgs e)
            {
                Process[] processes = Process.GetProcessesByName("chrome");
                Process[] array = processes;
                for (int i = 0; i < array.Length; i++)
                {
                    Process process = array[i];
                    process.Kill();
                }
                thr.Abort();
            }
