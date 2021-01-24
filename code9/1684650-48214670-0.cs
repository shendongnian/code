    [Table("UserRoleMapping")]
    public partial class UserRoleMappingModel
        {
            [Key, Column(Order = 0)]
            public Guid UserId { get; set; }
            public UserModel User { get; set; }
    
            [Key, Column(Order = 1)]
            public int RoleId { get; set; }
            public UserRoleModel UserRole { get; set; }
        }
