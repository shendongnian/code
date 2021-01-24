	[Test]
	public void Readcontent()	
	{
        using (WebClient client = new WebClient())
        {
            string url = "https://sampleweb.com";
            string content = client.DownloadString(url);
            Assert.That(content, Contains.Substring("XYZ"), "String not found in entire page content.");
		}
	}
