    KeyValuePair<string, Schema> kvpSchema = context.SchemaRegistry.Definitions.Where(x => x.Key == kvpResponse.Value.Schema.Ref.Replace("#/definitions/", String.Empty)).FirstOrDefault();
				string strTmp = kvpResponse.Value.Examples.ToString();
				foreach (KeyValuePair<string, Schema> kvpProperty in kvpSchema.Value.Properties)
				{
                   kvpProperty.Value.Example = ...;
                }
