     private void btnLookup_Click(object sender, EventArgs e)
        {
            string templateUrl = @"https://www.google.co.uk/search?q={0}&tbm=isch&site=imghp";
            //check that we have a term to search for.
            if (string.IsNullOrEmpty(tbSearch.Text))
            {
                MessageBox.Show("Please supply a search term"); return;
            }
            else
            {
                using (WebClient wc = new WebClient())
                {
                    //lets pretend we are IE8 on Vista.
                    wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0)");
                    string result = wc.DownloadString(String.Format(templateUrl, new object[] { tbSearch.Text }));
                    //we have valid markup, this will change from time to time as google updates.
                    if (result.Contains("images_table"))
                    {
                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(result);
                        //lets create a linq query to find all the img's stored in that images_table class.
                        /*
                         * Essentially we get search for the table called images_table, and then get all images that have a valid src containing images?
                         * which is the string used by google
                        eg  https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQmGxh15UUyzV_HGuGZXUxxnnc6LuqLMgHR9ssUu1uRwy0Oab9OeK1wCw
                         */
                        var imgList = from tables in doc.DocumentNode.Descendants("table")
                                   from img in tables.Descendants("img")
                                   where tables.Attributes["class"] != null && tables.Attributes["class"].Value == "images_table"
                                   && img.Attributes["src"] != null && img.Attributes["src"].Value.Contains("images?")
                                   select img;
                        
                       byte[] downloadedData =  wc.DownloadData(imgList.First().Attributes["src"].Value);
                        if (downloadedData != null)
                        {
                            //store the downloaded data in to a stream
                            System.IO.MemoryStream ms = new System.IO.MemoryStream(downloadedData, 0, downloadedData.Length);
                            //write to that stream the byte array
                            ms.Write(downloadedData, 0, downloadedData.Length);
                            //load an image from that stream.
                            pbImage.Image = Image.FromStream(ms);
                        }
                    }
                }
            }
        }
