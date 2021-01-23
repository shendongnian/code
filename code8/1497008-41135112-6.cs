	string somevar = "rtf"; //string to eliminate
	List<string> subStrings = new List<string>();
	for(int i = 0; i < somevar.Length; i++)
	{
		subStrings.AddRange(GetAllSubStrings(somevar, i + 1));
	}
	RichTextBox1.Rtf = RichTextBox1.Rtf.ToLower();
	string[] textArray = RichTextBox1.Text.Split(new char[] { '\n', '\t' });
	foreach(string strText in textArray)
	{
		if(!string.IsNullOrEmpty(strText))
			if(!subStrings.Any(x => strText == x))
			{
				if(RichTextBox1.Rtf.Contains(strText))
				{
					RichTextBox1.Rtf = RichTextBox1.Rtf.Replace(strText, strText.ToUpperInvariant());
				}
				else
				{
					RichTextBox rt = new RichTextBox();
					rt.Text = strText;
					string rtftext = rt.Rtf.Substring(rt.Rtf.IndexOf("fs17") + 4);
					rtftext = rtftext.Substring(0, rtftext.IndexOf("par")-1);
					RichTextBox1.Rtf = RichTextBox1.Rtf.Replace(rtftext, strText.ToUpperInvariant());
				}
			}
	}
