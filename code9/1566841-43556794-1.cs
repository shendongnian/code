    namespace JsonSchemaClassGenerator.TestSchema
    {
        public partial class Object
        {
            public static implicit operator Object(JObject json)
            {
                return FromJson(json.ToString());
            }
        }
    }
