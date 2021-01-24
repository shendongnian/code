    public class SwaggerOperationFilter : IOperationFilter
    {
        #region Fields
        private const string testpropertyname = "TestProperty";
        private const string TestSchemaRef = "ADef";
        private static Schema TestSchema = new Schema { Required = new List<string> { testpropertyname }, Example = new { TestProperty = "Test" }, Description = "This is a Description", Title = "TestSchema", Properties = new Dictionary<string, Schema>() };
        #endregion
    
        #region Static Constructor
        static SwaggerOperationFilter()
        {
            TestSchema.Properties.Add(testpropertyname, new Schema { Type = "string" });
        }
        #endregion
    
        #region Implementation
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (!context.SchemaRegistry.Definitions.ContainsKey(TestSchemaRef))
            {
                context.SchemaRegistry.Definitions.Add(TestSchemaRef, TestSchema);
            }
    
            operation.Responses["200"] = new Response
            {
                Description = "This is a Response Description",
                Schema = TestSchema
            };
        }
        #endregion
    }
