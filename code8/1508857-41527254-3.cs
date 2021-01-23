    public class WorkRole
        {
            [Key]
    
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
            public int WorkRoleId { get; set; }
            public string RoleName { get; set; }
            public string RoleDescription { get; set; }
            public int Foo {get; set;}
            [ForeignKey("Foo")]
            public virtual Company Company { get; set; }
        }
