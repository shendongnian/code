	public static class JsonExtensions
	{
		public static bool TestValidate<T>(T obj, JSchema schema, SchemaValidationEventHandler handler = null, JsonSerializerSettings settings = null)
		{
			using (var writer = new NullJsonWriter())
			using (var validatingWriter = new JSchemaValidatingWriter(writer) { Schema = schema })
			{
				int count = 0;
				if (handler != null)
					validatingWriter.ValidationEventHandler += handler;
				validatingWriter.ValidationEventHandler += (o, a) => count++;
				JsonSerializer.CreateDefault(settings).Serialize(validatingWriter, obj);
				return count == 0;
			}
		}
	}
	// Used to enable Json.NET to traverse an object hierarchy without actually writing any data.
	class NullJsonWriter : JsonWriter
	{
		public NullJsonWriter()
			: base()
		{
		}
	
		public override void Flush()
		{
			// Do nothing.
		}
	}
