    public class ProductMetadata
    {
    
        [ScaffoldColumn(true)]
        [StringLength(10, ErrorMessage= "The file name cannot exceed 10 characters long")]
        public object ProductNumber;
    }
