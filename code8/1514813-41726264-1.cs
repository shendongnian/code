	public sealed class ParameterModel
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public BooleanAsString Nullable { get; set; }
		public BooleanAsString AllowBlank { get; set; }
		public BooleanAsString MultiValue { get; set; }
		public BooleanAsString UsedInQuery { get; set; }
		public string State { get; set; }
		public string Prompt { get; set; }
		public BooleanAsString DynamicPrompt { get; set; }
		public BooleanAsString PromptUser { get; set; }
		public List<Dependency> Dependencies { get; set; }
		public BooleanAsString DynamicValidValues { get; set; }
		public BooleanAsString DynamicDefaultValue { get; set; }
	}
	public sealed class Dependency
	{
		[XmlText]
		public string Value { get; set; }
	}
