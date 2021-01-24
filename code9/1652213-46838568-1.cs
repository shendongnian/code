    using System.ComponentModel.DataAnnotations.Schema;
    ...
    [ForeignKey("Article")]
    public int? ArticleId { get; set; }
    [ForeignKey("User")]
    public Guid UserId { get; set; }
