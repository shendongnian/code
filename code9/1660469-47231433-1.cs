        var possibleAttributes = new List<ITextExtractor>{
			new TextExtractor<TestDescription>(a => a.Desc),
			new TextExtractor<DescriptionAttribute>(a => a.Description)};
		
		foreach (var possibleAttribute in possibleAttributes)
    	{
			var attribute = possibleAttribute.GetAttribute(field);
			if (attribute != null) return possibleAttribute.GetText(attribute);
        
    	}
