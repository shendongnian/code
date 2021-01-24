	{
		webBrowser1.Navigate(new Uri(textBox1.Text));
	}
	{
		HtmlDocument doc = webBrowser1.Document;
		HtmlElementCollection classButton = webBrowser1.Document.All;
		...
	}
