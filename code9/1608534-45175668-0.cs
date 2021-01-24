    string link = "";
    foreach (SyndicationItem syndicationItem in rssFormatter.Feed.Items)
    {
        Console.OutputEncoding = Encoding.UTF8;
        // You have to check if `syndicationItem.Links` has more than 1 element.
        if (syndicationItem.Links.Count > 0)
        {
            // this is the line that shows you the url of the "enclosure" tag:
            link = syndicationItem.Links[1].Uri.ToString();
        }
    
        // Prints the Image's src.
        Console.WriteLine("Image src: " + link);
    }
