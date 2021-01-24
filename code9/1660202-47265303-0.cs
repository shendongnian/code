    namespace ProductVersionModel.Model
    {
        using System;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;
    
        /// <summary>
        /// all common properties of the tables are defined here
        /// </summary>
        public class BaseModel
        {
            /// <summary>
            /// id of the table
            /// </summary>
            [Key]
            public int Id { get; set; }
            
            /// <summary>
            /// user id of the user who modified last 
            /// </summary>
            public string LastModifiedBy { get; set; }
    
            /// <summary>
            /// last modified time
            /// </summary>
            public DateTime LastModifiedTime { get; set; }
    
    
            /// <summary>
            /// record created user id
            /// </summary>
            [Required]
            public string CreatedBy { get; set; }
    
            /// <summary>
            /// record creation time
            /// </summary>
            public DateTime CreationTime { get; set; }
    
            /// <summary>
            /// Not mapped to database, only for quering used
            /// </summary>
            [NotMapped]
            public int RowNumber { get; set; }
        }
    }
