    public static IEnumerable<CustomProperty> GetCustomDocumentProperties(Workbook workbook)
    {
    	foreach (CustomProperty property in workbook.CustomDocumentProperties)
    	{
    		yield return property;
    	}
    }
