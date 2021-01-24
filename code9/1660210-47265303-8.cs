    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ProductVersionModel.Model.History;
    
    // ReSharper disable once CheckNamespace
    namespace ProductVersionModel.Model.History
    {
        public class ProductStatusHistory : HistroyBaseModel
        {
            
            /// <summary>
            /// Name of the product
            /// </summary>
            [MaxLength(100)]
            public string Name { get; set; }
            
            /// <summary>
            /// product version validity start date
            /// </summary>
            public DateTime ValidFrom { get; set; }
    
            /// <summary>
            /// product version valid till
            /// </summary>
            public DateTime? ValidTill { get; set; }
    
            /// <summary>
            /// This field used to keep track of history of a product
            /// </summary>
            public int ProductNumber { get; set; }
            
        }
    }
