        List<string> URLS = new List<string>(); //fill this list with your URLs in order of combobox options
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Download(comboBox1.SelectedIndex);
        }
        private void Download(int LinkIndex)
        {
            string Download_Link = URLS[LinkIndex];
        }
