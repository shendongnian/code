    public class PayableAmountAttribute : ValidationAttribute, IMetadataAware
    {       
        public override bool IsValid(object Value)
        {
            // Implementation of looping through validation attributes
        }
        public void OnMetadataCreated(ModelMetadata Metadata)
        {
            Metadata.TemplateHint = "Amount";
            Metadata.AdditionalValues.Add("Amount.MaxLength", 10);
        }
    }
