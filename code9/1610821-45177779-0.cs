    namespace SameNamespaceAsEntities
    {
    internal sealed class TheEntityMetadata
    {
        //AStringInTheEntity appears twice in your project
        //once in the auto gen file, and once here
        [Required(ErrorMessage = "Field is required.")]
        public string AStringInTheEntity{ get; set; }
    }
    //http://stackoverflow.com/questions/14059455/adding-validation-attributes-with-an-entity-framework-data-model
    [System.ComponentModel.DataAnnotations.MetadataType(typeof(TheEntityMetadata))]
    public partial class TheEntity : IEntity //you can set contracts
    {
