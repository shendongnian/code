    foreach (var HeaderFooterReplacement in EmailTemplateConfig)
    {
    	if (headerFooterContents.Contains(HeaderFooterReplacement.Placeholder))
    	{
    		headerFooterContents = headerFooterContents.Replace(HeaderFooterReplacement.Placeholder, HeaderFooterReplacement.Value);
    	}
    }
