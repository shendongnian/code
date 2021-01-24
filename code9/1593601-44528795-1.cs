    public static void AssertMatchTemplate(string message, string template)
    {
    	var templateParts = Regex.Split(template,"\\{.*?}")
    	foreach (var templatePart in templateParts)
    		Assert.IsTrue(message.Contains(templatePart));
    }
