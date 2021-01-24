    public partial class Store
        {
            public int StoreID { get; set; }
            public int CustomerID { get; set; }
            public string StoreName { get; set; }
    
            public System.Guid StoreUID { get; set; }
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int StoreNumber { get; set; }
            public string StoreLogo { get; set; }
            public string StoreLogoPath { get; set; }
            public string StoreAddress { get; set; }
            public string StoreCity { get; set; }
            public string StoreRegion { get; set; }
            public string StoreCountry { get; set; }
    
            public virtual Customer Customer { get; set; }
        }
   
