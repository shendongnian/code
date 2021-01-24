     string ContentURL = attachment.ContentUrl;
                string name = attachment.Name;
                using (var client = new WebClient())
                {
                client.DownloadFile(ContentURL, name); }
