    public class Custom
    {
    [Key]
    [Column(Order = 1)]
    public virtual string Client { get; set; }
    [Key]
    [Column(Order = 2)]
    public virtual string Portfolio { get; set; }
    [Required]
    public virtual decimal AUM { get; set; }
    [Key]
    [Column(Order = 3)]
    public DateTime EffectiveDate { get; set; }
    [StringLength(50)]
    [Column(TypeName = "char")]
    public string IsStatic { get; set; }
    [Required]
    public DateTime sysDate { get; set; }
    [StringLength(500)]
    public virtual string ModifiedBy { get; set; }
    }
