    private ResourceDictionary LoadDictionary(string source)
		{
			Stream streamInfo = null;
			ResourceDictionary dictionary = null;
			try
			{
				streamInfo = DistantManager.Instance.GetResource(source);
				if (streamInfo != null)
				{
					Uri baseUri = DistantManager.Instance.GetUri(source);
					dictionary = XamlReader.Load(streamInfo) as ResourceDictionary;
					dictionary.Source = baseUri;
				}
			}
			catch (Exception e)
			{
                BusinessLogger.Manage(e);
				return null;
			}
			return dictionary;
		}
