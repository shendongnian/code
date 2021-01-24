	public void ReplaceBookmarkText(WP.BookmarkStart bookmark, string newText)
	{
		try
		{
			var bmkText = bookmark.NextSibling<WP.Run>();
			if (bmkText != null)
			{
				bmkText.GetFirstChild<WP.Text>().Text = newText;
				wordprocessingDocument.MainDocumentPart.Document.Save();
			}
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex.Message);
			throw;
		}            
	}
