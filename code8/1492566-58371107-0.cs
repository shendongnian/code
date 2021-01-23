		WordprocessingDocument wDoc;
		try
		{
			using (wDoc = WordprocessingDocument.Open(newFileName, true))
			{
				//Try do something
			}
		}
		catch (OpenXmlPackageException e)
		{
			if (e.ToString().Contains("Invalid Hyperlink"))
			{
				using (FileStream fs = new FileStream(newFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
				{
                    //Fix problematic URI's
					OpenXmlPowerTools.UriFixer.FixInvalidUri(fs, brokenUri => FixUri(brokenUri));
				}
				using (wDoc = WordprocessingDocument.Open(newFileName, true))
				{
					//Do something without error
				}
			}
		}
