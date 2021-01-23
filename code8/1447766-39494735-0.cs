       namespace MyWebSIte.DataModel
        {
            using System;
            using System.Collections.Generic;
            using System.ComponentModel;
            using System.ComponentModel.DataAnnotations;
        
        	[MetadataType(typeof(ItemMovementMetaData))]
            public partial class ItemMovement
            {
                public System.Guid ID { get; set; }        
                public System.DateTime? Changed { get; set; }
        	}
        	
        	public partial class ItemMovementMetaData {
        
              	[DataType(DataType.DateTime)]
                [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
                [Display(Name = "Fecha")]
                public System.DateTime? Changed { get; set; }	
        		
        		//....................
        	}
        }
