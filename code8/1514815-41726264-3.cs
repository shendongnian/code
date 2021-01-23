		static string XmlSerialize(Object o)
		{
			var serializer = new XmlSerializer(o.GetType());
			using (var writer = new StringWriter())
			{
				serializer.Serialize(writer, o);
				return writer.ToString();
			}
		}
		static void Main(string[] args)
		{
			var parameters = new ParametersModel { UserProfileState = 0, Parameters = new List<ParameterModel>() };
			parameters.Parameters.Add(new ParameterModel
			{ Name = "County", Type = "String", Nullable = false, AllowBlank = false, MultiValue = true, UsedInQuery = true, State = "MissingValidValue", Prompt = "County", DynamicPrompt = false, PromptUser = true, DynamicValidValues = true, DynamicDefaultValue = true});
			var pm = new ParameterModel
			{ Name = "City", Type = "String", Nullable = false, AllowBlank = false, MultiValue = true, UsedInQuery = true, State = "MissingValidValue", Prompt = "City", DynamicPrompt = false, PromptUser = true, DynamicValidValues = true, DynamicDefaultValue = true };
			pm.Dependencies = new List<Dependency>() { new Dependency{ Value = "Country" } };
			parameters.Parameters.Add(pm);
			var s = XmlSerialize(parameters);
		}
