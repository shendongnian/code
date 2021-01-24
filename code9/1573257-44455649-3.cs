    class MyODataSerializerProvider : DefaultODataSerializerProvider
    {
        public MyODataSerializerProvider(IServiceProvider rootContainer)
            : base(rootContainer)
        {
        }
        public override ODataEdmTypeSerializer GetEdmTypeSerializer(IEdmTypeReference edmType)
        {
            if (edmType.Definition.TypeKind == EdmTypeKind.Entity)
                return new MyODataResourceSerializer(this);
            else
                return base.GetEdmTypeSerializer(edmType);
        }
    }
    class MyODataResourceSerializer : ODataResourceSerializer
    {
        public MyODataResourceSerializer(ODataSerializerProvider serializerProvider)
            : base(serializerProvider)
        {
        }
        public override ODataProperty CreateStructuralProperty(IEdmStructuralProperty structuralProperty, ResourceContext resourceContext)
        {
            ODataProperty
                property = base.CreateStructuralProperty(structuralProperty, resourceContext);
            if (resourceContext.StructuredType.FullTypeName() == typeof(Customer).FullName)
            {
                switch (property.Name)
                {
                    case "Prop":
                        property.Value = 0;
                        break;
                }
            }
            return property;
        }
    }
