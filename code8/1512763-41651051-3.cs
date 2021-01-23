	public void ReplaceValue(XElement element, string oldValue, string newValue)
	{
		if (element.HasElements)
		{
			foreach (var elem in element.Descendants())
			{
				ReplaceValue(elem, oldValue, newValue);
			}
		}
		else if (element.Value == oldValue)
		{
			element.Value = newValue;
		}
	}
