    public class WorkRole
        {
            [Key]
    
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
            public int WorkRoleId { get; set; }
            public string RoleName { get; set; }
            public string RoleDescription { get; set; }
            public int CompanyId {get; set;}// this will be mapped as foreign key by EF convention.
            public virtual Company Company { get; set; }
        }
