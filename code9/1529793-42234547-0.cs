        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                string s = client.DownloadString(url);
            }
        }
