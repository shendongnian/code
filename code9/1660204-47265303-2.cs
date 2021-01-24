    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    namespace ProductVersionModel.Model.History
    {
        public class HistroyBaseModel
        {
    
            /// <summary>
            /// id of the table
            /// </summary>
            [Key,  DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int Id { get; set; }
    
            public string DeletedBy { get; set; }
    
            public DateTime? DeletedTime { get; set; }
            /// <summary>
            /// record created user id
            /// </summary>
            [Required]
            public string CreatedBy { get; set; }
    
            /// <summary>
            /// record creation time
            /// </summary>
            public DateTime CreationTime { get; set; }
        }
    }
