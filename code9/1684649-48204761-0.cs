    [Table("User")]
    public partial class UserModel
    {
        public UserModel()
        {
            UserRole = new HashSet<UserRoleModel>();
        }
        public int UserID { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<UserRoleMappingModel> Mappings { get; set; }
        public virtual ICollection<UserRoleModel> UserRole
        {
            get
            {
                return this.Mappings.Select(s => s.UserRole);
            }
        }
    }
