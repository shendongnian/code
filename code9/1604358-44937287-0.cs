	private static IEnumerable<Attribute> MyMethod(IEnumerable<Attribute> attributes)
	{
		foreach (Attribute attribute in attributes)
		{
			if (attribute is HttpGetAttribute)
			{
				// cast to HttpGetAttribute to get properties
			}
			else if (attribute is RouteAttribute)
			{
				// cast to RouteAttribute to get properties
			}
			else if (attribute is ActionInfoAttribute)
			{
				// cast to ActionInfoAttribute to get properties
			}
		}
		return null;
	}
