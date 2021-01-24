    private void Crawl(List<String> links)
    {
        //////////////////////////////////
        // Check for something to work on
        if (links == null || links.Count == 0)
            return; // Return if there is nothing to do.
        //////////////////////////////////
        List<String> scrapedLinks = new List<String>();
        foreach (string link in links)
        {
            List<String> scrapedItems = Scrape(link, new Regex(iTalk_TextBox_Small2.Text), new WebClient());
            foreach (string item in scrapedItems) listBox1.Invoke(new Action(delegate () { listBox1.Items.Add(item); }));
            iTalk_Label4.Invoke(new Action(delegate () { iTalk_Label4.Text = "Scraped Items: " + listBox1.Items.Count; }));
            if (scrapedItems.Count > 0 || !Properties.Settings.Default.Inspector)
            {
                foreach (string scrapedLink in Scrape(link, new Regex(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)"), new WebClient()))
                {
                    if(!Properties.Settings.Default.Blacklist.Contains(scrapedLink)) scrapedLinks.Add(scrapedLink);
                }
                scrapedLinksTotal += scrapedLinks.Count;                
            }
            iTalk_Label5.Invoke(new Action(delegate () { iTalk_Label5.Text = "Scraped Links: " + scrapedLinksTotal; }));
        }
        Crawl(scrapedLinks);
    }
