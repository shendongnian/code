	public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
	{
		var testObject = obj as TestObject;
		if (testObject != null)
		{
			// Create the representation. This is a simplified example.
			Dictionary<string, object> result = new Dictionary<string, object>();
			result.Add("TestString", testObject.TestString);		
			return result;
		}
		
		return new Dictionary<string, object>();
	}
