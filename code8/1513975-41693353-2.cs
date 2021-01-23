	public static void ConvertNestedJsonToSimpleJson(JObject input, JObject output, string prefix = "")
	{
		foreach (JProperty jprop in input.Properties())
		{
			var name = prefix==""?jprop.Name:String.Format("{0}__{1}", prefix,jprop.Name);
			if (jprop.Children<JObject>().Count() == 0)
			{
				output.Add(name, jprop.Value);
			}
			else
			{
				ConvertNestedJsonToSimpleJson((JObject)jprop.Value, output, name);
			}
		}
	}
