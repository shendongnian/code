    public class AdjustmentType : AuditableEntity
    { //Good...
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdjustmentTypeId { get; set; }
    
        [Column("AdjustmentType")]
        [StringLength(50)]
        public string AdjustmentType1 { get; set; }
    
        public virtual ICollection<AdjustmentReasonType> AdjustmentReasonType { get; set; }
    }
    
    public class AdjustmentReason : AuditableEntity
    { //Good...
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdjustmentReasonId { get; set; }
    
        [Column("AdjustmentReason")]
        [StringLength(50)]
        public string AdjustmentReason1 { get; set; }
    
        public bool? Hidden { get; set; }
    
        public ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<AdjustmentReasonType> AdjustmentReasonType { get; set; }      
    }
    
    public class AdjustmentReasonType : AuditableEntity
    { // Remove the FKs...
        public int AdjustmentReasonTypeId { get; set; }
    
        //public int AdjustmentReasonId { get; set; } //This is required
    
        //public int AdjustmentTypeId { get; set; } //This is optional
    
        public virtual AdjustmentType AdjustmentType { get; set; }
    
        public virtual AdjustmentReason AdjustmentReason { get; set; }
    
    }
    
    //DatabaseContext.cs
    // Add the FK declarations here so that EF knows how to resolve these back to the parent references.
            modelBuilder.Entity<AdjustmentReason>()
                .HasMany(e => e.AdjustmentReasonTypes)
                .WithRequired(e => e.AdjustmentReason)
                .Map(e=> e.MapKey("AdjustmentReasonId"); // FK column name.
            modelBuilder.Entity<AdjustmentType>()
                .HasMany(e => e.AdjustmentReasonType)
                .WithRequired(e => e.AdjustmentType)
                .Map(e=> e.MapKey("AdjustmentTypeId");
    //IDatabaseContext.cs
            IDbSet<AdjustmentReason> AdjustmentReasons { get; set; }
    
            IDbSet<AdjustmentType> AdjustmentTypes { get; set; }
            // Remove these, typically you would be dealing with Reasons or Types, not the linking table directly. Use the references
            //IDbSet<AdjustmentReasonType> AdjustmentReasonTypes { get; set; }
