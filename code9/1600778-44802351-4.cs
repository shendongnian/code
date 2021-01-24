    private void btnHurriyet_Click(object sender, EventArgs e)
    {
        Hurriyet hurriyet = new Hurriyet();
        List<ListViewItem> list = hurriyet.GetTagsHurriyet();
    
        if (!list.Any())
            MessageBox.Show("Haberlerde değişiklik olmadı");
        else
        {
            foreach (var item in list)
                listView1.Items.Add(item);
        }
    }
    
    public static Dictionary<string, Hurriyet> HurriyetHaberList = new Dictionary<string, Hurriyet>();
    public List<ListViewItem> GetTagsHurriyet()
    {
        XmlDocument xdoc = new XmlDocument();
        xdoc.Load("http://www.hurriyet.com.tr/rss/gundem");
        XmlElement el = (XmlElement)xdoc.SelectSingleNode("/rss");
    
        if (el != null)
            el.ParentNode.RemoveChild(el);
    
        XmlNode Haberler = el.SelectSingleNode("channel");
        List<Hurriyet> newHurriyets = new List<Hurriyet>();
    
        bool degismiMi = false;
        foreach (XmlNode haber in Haberler.SelectNodes("item"))
        {
            var link = haber.SelectSingleNode("link").InnerText;
            if (HurriyetHaberList.ContainsKey(link))
                continue;
    
            Hurriyet h = new Hurriyet();
    
            h.Title = haber.SelectSingleNode("title").InnerText;
            if (!haber.SelectSingleNode("description").InnerText.Contains("&gt;"))
                h.Description = haber.SelectSingleNode("description").InnerText;
    
            h.Link = link;
    
            var format = DateTime.Parse(haber.SelectSingleNode("pubDate").InnerText.ToString());
            h.PubDate = format;
    
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                string final_response = stream.ReadToEnd();
                string begenningKeyword = "<meta name=\"keywords\" content=\"";
    
                var tags = final_response.IndexOf(begenningKeyword);
                var final_response2 = final_response.Substring(tags + begenningKeyword.Length);
                var tagsBol = final_response2.IndexOf("\" />");
    
                var lastTags = final_response2.Substring(0, tagsBol);
                int yer1;
    
                if (!string.IsNullOrEmpty(lastTags))
                    h.Tags = lastTags;
                else
                {
                    yer1 = final_response.IndexOf("tagsContainer");
    
                    if (yer1 == -1)
                        continue;
    
                    yer1 = final_response.IndexOf("tagsContainer");
                    int yer2 = final_response.IndexOf("</div>", yer1);
    
                    var tagDiv = final_response.Substring(yer1, yer2 - yer1);
    
                    List<string> listele = new List<string>();
                    for (int i = 0; i < tagDiv.Length; i++)
                    {
                        var firstSpan = tagDiv.IndexOf("<span>");
                        var firstSpan2 = tagDiv.IndexOf("<span itemprop=\"keywords\">");
    
                        if (firstSpan != -1)
                        {
                            var secondSpan = tagDiv.IndexOf("</a>", firstSpan);
                            var lastSpan = tagDiv.Substring(firstSpan, secondSpan - firstSpan);
                            var remo = lastSpan.Replace("<span>", "");
                            var remo2 = remo.Replace("</span>", "");
                            listele.Add(remo2);
    
                            tagDiv = tagDiv.Replace(lastSpan, "");
                        }
                        else if (firstSpan2 != -1)
                        {
                            var secondSpan = tagDiv.IndexOf("</a>", firstSpan2);
                            var lastSpan = tagDiv.Substring(firstSpan2, secondSpan - firstSpan2);
                            var remo = lastSpan.Replace("<span itemprop=\"keywords\">", "");
                            var remo2 = remo.Replace("</span>", "");
                            listele.Add(remo2);
    
                            tagDiv = tagDiv.Replace(lastSpan, "");
                        }
                        else
                            break;
                    }
    
                    h.Tags = string.Join(",", listele);
                }
            }
    
            HurriyetHaberList.Add(link, h);
            newHurriyets.Add(h);
        }
    
        List<ListViewItem> listViewItems = new List<ListViewItem>();
        foreach (var item in newHurriyets.OrderByDescending(x => x.PubDate))
        {
            ListViewItem lstItem = new ListViewItem();
            lstItem.Text = item.Title;
            lstItem.SubItems.Add(item.Description);
            lstItem.SubItems.Add(item.Link);
            lstItem.SubItems.Add(item.PubDate.ToString());
            lstItem.SubItems.Add(item.Tags);
    
            listViewItems.Add(lstItem);
        }
    
        return listViewItems;
    }
