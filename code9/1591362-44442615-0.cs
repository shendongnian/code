    public abstract class BaseDepositorMapper : IMapper
    {
        private readonly IFormUIElementHelper _formHelper;
    
        public BaseDepositorMapper (IFormUIElementHelper formHelper)
        {
            _formHelper = formHelper;          
        }
    
        public bool CanMap(List<Fields> fields)
        {
            var taxId = _formHelper.GetFieldValue<string>(fields, GetDepositorTaxId());
    
            return !string.IsNullOrWhiteSpace(taxId);
        }
    	
    	public abstract DepositorTaxIdType GetDepositorTaxId();
    }
