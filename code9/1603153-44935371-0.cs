    String url = "https://keddr.com/feed/";
	XmlReader reader = XmlReader.Create(url);
    SyndicationFeed feed = SyndicationFeed.Load(reader);
    reader.Close();
				
	foreach (SyndicationItem item in feed.Items)
	{
		Console.WriteLine("Title: " + item.Title.Text);
		Console.WriteLine("Publish Date:" + item.PublishDate.ToString("MM/dd/yyyy HH:mm:ss"));
		Console.WriteLine("Link: " + item.Links[0].GetAbsoluteUri().ToString());
		Console.WriteLine(item.Summary.Text");
	}
