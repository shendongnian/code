    public class CustomPropertyTypeDescriptor : CustomTypeDescriptor
    {
    	public static void Register(Type type, params PropertyDescriptor[] customProperties)
    	{
    		var baseProvider = TypeDescriptor.GetProvider(type);
    		var typeDescriptor = new CustomPropertyTypeDescriptor(baseProvider.GetTypeDescriptor(type), customProperties);
    		TypeDescriptor.AddProvider(new Provider(baseProvider, typeDescriptor), type);
    	}
    	PropertyDescriptor[] customProperties;
    	private CustomPropertyTypeDescriptor(ICustomTypeDescriptor baseDescriptor, PropertyDescriptor[] customProperties)
    		: base(baseDescriptor)
    	{
    		this.customProperties = customProperties;
    	}
    	public override PropertyDescriptorCollection GetProperties() { return GetProperties(null); }
    	public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
    	{
    		return new PropertyDescriptorCollection(base.GetProperties(attributes).Cast<PropertyDescriptor>().Concat(customProperties).ToArray());
    	}
    	private class Provider : TypeDescriptionProvider
    	{
    		private CustomPropertyTypeDescriptor typeDescriptor;
    		public Provider(TypeDescriptionProvider baseProvider, CustomPropertyTypeDescriptor typeDescriptor)
    			: base(baseProvider)
    		{
    			this.typeDescriptor = typeDescriptor;
    		}
    		public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
    		{
    			return typeDescriptor;
    		}
    	}
    }
