        public class AccountsMetadata : MyTables.DataAccess.Metadata.Base.MyTableEntity {
        [Key]
        [Required]
        [UniqueValidator]        
        public string Code { get; set; }
        [Display(Name="Description")]
        [StringLength(100)]
        public string Description { get; set; }
        }
