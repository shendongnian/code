        private void save_Click(object sender, RoutedEventArgs e)
        {
            string postUrl = "https://api.twitch.tv/kraken/channels/" + this.channelID;
            string postData = "channel[status]=" + Uri.EscapeDataString(status.Text) +
                "&channel[game]=" + Uri.EscapeDataString(game.Text);
            byte[] postByte = Encoding.UTF8.GetBytes(postData);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);
            request.Method = "PUT";
            request.Accept = "application/vnd.twitchtv.v5+json";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postByte.Length;
            request.Headers.Add("Authorization", "OAuth " + password.Password);
            request.Headers.Add("Client-ID", this.clientID);
            request.Timeout = 15000;
            try
            {
                using (Stream putStream = request.GetRequestStream())
                {
                    putStream.Write(postByte, 0, postByte.Length);
                    using (var response = (HttpWebResponse) request.GetResponse())
                    {
                        //assign the response result to a variable else it's getting disposed
                    }
                }
            }
            catch (WebException err)
            {
                request.Abort();
                MessageBox.Show("Unable to update channel information:\n" + err.Message);
            }
        }
