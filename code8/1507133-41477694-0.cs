        public class ViewModel
        {
            public string Name { get; set; }
            public int InventoryNo { get; set; }
            public int SupplierNo { get; set; }
            public IList<SelectListItem> Suppliers {get;set;}    
        }
