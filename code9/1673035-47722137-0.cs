    private void timer1_Tick(object sender, EventArgs e)
    {
        // the enumerator has a Current, navigate to it
        webBrowser1.Navigate(websites.Current);
        // we stop the timer if there are no more websites
        timer1.Enabled = websites.MoveNext();
    }
    IEnumerator<string> websites; // this will keep track of the urls to navigate
    private void button1_Click(object sender, EventArgs e)
    {
        // set up a list with url's and then get its Enumarator
        websites = new List<string> {
            "https://mbasic.facebook.com/groups/516524655403741" ,
            "https://mbasic.facebook.com/groups/548734261950831"
        }.GetEnumerator();
        // enable the timer
        timer1.Enabled = true;
        // make sure our enumerator is going
        websites.MoveNext();
    }
