        public Form1()
        {
            // (...)
            this.FormClosing += this.Form1_FormClosing;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            driver.Quit();
            Environment.Exit(0);
        }
