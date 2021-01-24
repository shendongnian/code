    public class CustomValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
    {
    	private readonly IValidationAttributeAdapterProvider _baseProvider = new ValidationAttributeAdapterProvider();
    
    	public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
    	{
    		if (attribute is RequiredIfAttribute)
    			return new RequiredIfAttributeAdapter(attribute as RequiredIfAttribute, stringLocalizer);
    		else
    			return _baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
    	}
    }
