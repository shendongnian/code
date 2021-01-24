    public class RequiredIfAttributeAdapter : AttributeAdapterBase<RequiredIfAttribute>
    {
    	public RequiredIfAttributeAdapter(RequiredIfAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer) {}
    
    	public override void AddValidation(ClientModelValidationContext context) {}
    
    	public override string GetErrorMessage(ModelValidationContextBase validationContext)
    	{
    		return GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName());
    	}
    }
