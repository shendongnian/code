    public class ProductViewModelItems
    {
        public IList<ProductViewModel> items { get; set; } = new List<ProductViewModel>();
    }
    
    public class ProductViewModel
    {
        public Guid q_guid { get; set; }
    
        public decimal q_sellprice { get; set; }
    
        public decimal q_casecost { get; set; }
    
        //other properties
    }
