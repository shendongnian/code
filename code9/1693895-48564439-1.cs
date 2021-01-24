            private void button1_Click(object sender, EventArgs e)
        {
            var picFilePath = @"C:\PictureFromInsta.jpg";
            WebClient Client = new WebClient();
            Client.DownloadFile("https://api.instagram.com/v1/users/7030608823/media/recent/?access_token=7030608823.1677ed0.f5877671841d4751af1de0c307b55d04", @"H:\jsonLink.json");
            string json = File.ReadAllText(@"H:\jsonLink.json");
            JObject obj = JObject.Parse(json);
            var valueArray = obj["data"][0]["link"].Value<string>();
            
            if (valueArray.ToString().Contains("https://www.instagram.com"))
            {
                string link = valueArray.ToString();
                Client.DownloadFile(link, picFilePath);
                WebBrowser webBrowser1 = new WebBrowser();
                webBrowser1.Navigate(link);
            }
            PictureBox p = new PictureBox();
            p.ImageLocation = picFilePath;
        }
