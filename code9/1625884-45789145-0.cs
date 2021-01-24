	System.Windows.Forms.HtmlDocument doc = webBrowser1.Document; 
	HtmlElementCollection col = doc.GetElementsByTagName("a");
	int i = 0;
	foreach (HtmlElement element in col)
	{
		textBox8.Text = textBox8.Text + col[i].GetAttribute("id") + "\r\n";
		i = i + 1;
		
		// check if parent is dd
		if(element.Parent != null && element.Parent.TagName.ToLower() == "dd")
		{
			var parent = element.Parent;
			
			if(parent.Parent != null && element.Parent.TagName.ToLower() == "dl")
			{
				// get class name of dl
				var className = parent.Parent.GetAttribute("class");
			}
		}
	}
