    public enum Permission {
        Not = 0, Read = 1, Analyse = 2, Edit = 3, Admin = 4
    }
    public class Group {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        [Required]
        public bool IsOperations { get; set; }
        public Permission? OperationPermission { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
