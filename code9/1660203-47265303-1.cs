    namespace ProductVersionModel.Model
    {
        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        /// <summary>
        /// store detals of the product
        /// </summary>
        public class ProductStatus : BaseModel
        {
            /// <summary>
            /// Name of the product
            /// </summary>
            [Required, MaxLength(100)]
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
