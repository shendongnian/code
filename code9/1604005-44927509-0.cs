    public class StoreTransactionAngular
    {
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.Labels), ErrorMessageResourceName = "Required")]
        public int StoreId { get; set; }
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.Labels), ErrorMessageResourceName = "Required")]
        public int TargetId { get; set; }
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.Labels), ErrorMessageResourceName = "Required")]
        public DateTime TransactionDate { get; set; }
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.Labels), ErrorMessageResourceName = "Required")]
        [MustHaveOneElementAttribute(ErrorMessage = "At least a task is required")]
        [MinLength(1)]
        [EnsureOneElement(ErrorMessage = "At least a person is required")]
        public List<StoreTransactionDetails> Details { get; set; }    
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.Labels), ErrorMessageResourceName = "Required")]
        public string ItemIds { get; set; }
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.Labels), ErrorMessageResourceName = "Required")]
        public string Quantities { get; set; }
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.Labels), ErrorMessageResourceName = "Required")]
        public string IsUseds { get; set; }    
    }
