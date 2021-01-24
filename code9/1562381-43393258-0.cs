    foreach (SyndicationItem item in feed.Items)
    {
        string link = item.Links[0].Uri.ToString();
        string text = item.Summary.Text;
    }
