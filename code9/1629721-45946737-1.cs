    public class CustomValidationHtmlAttributeProvider : DefaultValidationHtmlAttributeProvider
    {
    	private readonly IModelMetadataProvider metadataProvider;
    
    	public CustomValidationHtmlAttributeProvider(IOptions<MvcViewOptions> optionsAccessor, IModelMetadataProvider metadataProvider, ClientValidatorCache clientValidatorCache)
    		: base(optionsAccessor, metadataProvider, clientValidatorCache)
        {
    		this.metadataProvider = metadataProvider;
    	}
    
    	public override void AddValidationAttributes(ViewContext viewContext, ModelExplorer modelExplorer, IDictionary<string, string> attributes)
    	{
    		//base implimentation
    		base.AddValidationAttributes(viewContext, modelExplorer, attributes);
    
    		//re-create the validation context (since it's encapsulated inside of the base implimentation)
    		var context = new ClientModelValidationContext(viewContext, modelExplorer.Metadata, metadataProvider, attributes);
    
    		//Only proceed if it's the model you need to do custom logic for
    		if (!(modelExplorer.Container.Model is MyViewModelClass model) || !modelExplorer.Metadata.PropertyName == "Myprop") return;
    
    		//Do stuff!
    		var validationAttributeAdapterProvider = viewContext.HttpContext.RequestServices.GetRequiredService<IValidationAttributeAdapterProvider>();
    
    		if (model.Myprop)
    		{
    			var validationAdapter = (RequiredAttributeAdapter)validationAttributeAdapterProvider.GetAttributeAdapter(new RequiredAttribute(), null);
    			validationAdapter.Attribute.ErrorMessage = "You not enter right stuff!";
    			validationAdapter.AddValidation(context);
    		}
    	}
    }
