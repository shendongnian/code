    public abstract class BaseModel<TId>
    {
        TId Id { get; set; }
    
        [Column(TypeName = "datetime2")]
        DateTime CreateDate { get; set; }
    
        [Required]
        [StringLength(255)]
        string CreateUser { get; set; }
    
        bool Deleted { get; set; }
    }
    class Model : BaseModel<Guid>{ ... //model specific stuff }
