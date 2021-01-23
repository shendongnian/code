    public class MyPropertyVisitor : NoopPropertyVisitor
    {
        public override void Visit(IDateProperty type, PropertyInfo propertyInfo, ElasticsearchPropertyAttributeBase attribute)
        {
            if (propertyInfo.DeclaringType == typeof(MyDocument) &&
                propertyInfo.Name == nameof(MyDocument.DateOfBirth))
            {
                type.NullValue = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            }
        }
    }
    var visitorMappingResponse = client.Map<MyDocument>(m => m
        .Index("index-name")
        .AutoMap(new MyPropertyVisitor())
    );
