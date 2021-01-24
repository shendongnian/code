    public static void AssertMatchTemplate(string message, string template)
    {
    	var placeholders = Enumerable.Range(0, 20).Select(n => @"{{n}}").ToArray();
    	var templateParts = template.Split(placeholders, StringSplitOptions.RemoveEmptyEntries);
    	foreach (var templatePart in templateParts)
    		Assert.IsTrue(message.Contains(templatePart));
    }
