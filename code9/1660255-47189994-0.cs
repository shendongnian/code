    [MetadataType(typeof(EmployeeTypeMetaData))]
    public partial class EmployeeType  { }
    public class EmployeeTypeMetaData
    {
        [Required(ErrorMessage = "Title is required.")]
        public object Title;
        // etc
    }
