        public void showSource()  // <<<<<<<<<<<<<<<<<<<<<<<<<< Call this function
        {
            Task ts = getSource();
        }
        private async Task getSource()
        {
            try
            {
                //
                string source = await chromeBrowser.GetBrowser().MainFrame.GetSourceAsync();
                //
                string f = Application.StartupPath + "\\currentSource.txt";
                //
                StreamWriter wr = new StreamWriter(f, false, System.Text.Encoding.Default);
                wr.Write(source);
                wr.Close();
                //
                System.Diagnostics.Process.Start(f);
                //
            }
            catch (Exception)
            {
                //Error !
            }
        }
