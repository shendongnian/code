			var settingsOut = new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
				NullValueHandling = NullValueHandling.Ignore,
			};
			var jsonWithoutRef = JsonConvert.SerializeObject(root, settingsOut);
			Console.WriteLine("Re-serialized with PreserveReferencesHandling.None");
			Console.WriteLine(jsonWithoutRef);
