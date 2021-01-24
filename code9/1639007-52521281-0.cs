    var result = await _client.PutIndexTemplateAsync(
        p.TemplateName, s=>s
            .Template(p.Template)
            .Mappings(m=>m
                .Map(p.TemplateName, mm=>mm
                    .AutoMap<MyType>(new EnumAsStringPropertyVisitor())
                )
            ));
    public class EnumAsStringPropertyVisitor : NoopPropertyVisitor
    {
        public override void Visit(
            INumberProperty type,
            PropertyInfo propertyInfo,
            ElasticsearchPropertyAttributeBase attribute) 
        {
            if(propertyInfo.PropertyType.IsEnum)
            { 
                type.Type = "keyword"; 
            }
        }
    }
