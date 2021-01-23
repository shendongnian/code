public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
{
  var excludeProperties = new[] { "myProp1", "myProp2, myProp3"};
   foreach (var prop in excludeProperties)
	<b><i> if(schema.properties != null) // This line</i></b>
	   if (schema.properties.ContainsKey(prop))
		schema.properties.Remove(prop);        
}
