    public class UserCompany
    {
       [Key, Column(Order = 1)]
       public string UserId { get; set; }
       
       [ForeignKey("UserId ")]
       public virtual ApplicationUser ApplicationUser { get; set; }
       [Key, Column(Order = 2)]
       public string DataAreaId { get; set; }
       [ForeignKey("DataAreaId")]
       public virtual Company Company { get; set; }
    }
