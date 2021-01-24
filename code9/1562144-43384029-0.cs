    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Key, Column(Order = 2)]
    [MaxLength(128)]
    public string UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual ApplicationUser User { get; set; }
