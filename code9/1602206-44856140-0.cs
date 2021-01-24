		static void Main(string[] args)
		{
			var json = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string,JObject>>(
				jsonString,
				new Newtonsoft.Json.JsonSerializerSettings()
				{
					DateParseHandling = Newtonsoft.Json.DateParseHandling.None,
				});
			foreach (var item in json)
			{
				var key = item.Key; // "subform_12"
				var val = item.Value;
				Console.WriteLine(key+":");
				foreach (var field in val)
				{
					var fieldKey = field.Key; // e.g. "multiline_2"
					var fieldVal = field.Value; // e.g. "Subform 1 Long Text"
									   
					Console.WriteLine($"{fieldKey}={fieldVal.Value<string>()}");                    
				}
				Console.WriteLine();
			}
		}
