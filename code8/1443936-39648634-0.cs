    internal sealed class AgencyReferredToMetadata
    {
        //since this is used in a modal, we are really only using the error text 
        //of the validationSummary not the ValidationMessageFor
        [Required(ErrorMessage = "AgencyReferredTo is required.")]
        public string AgencyReferredTo1 { get; set; }
    }
    //http://stackoverflow.com/questions/14059455/adding-validation-attributes-with-an-entity-framework-data-model
    [System.ComponentModel.DataAnnotations.MetadataType(typeof(AgencyReferredToMetadata))]
    public partial class AgencyReferredTo : IEntity
