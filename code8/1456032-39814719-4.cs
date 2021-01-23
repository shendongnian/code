      public class UserTag {
      
        [StringLength(128)]
        [Required]
        [Index("UI_UserGroupTagtext", 2, IsUnique = true)]
        public string TagText { get; set; }
    
        [Index("UI_UserGroupTagtext", 1, IsUnique = true)]
        public int UserGroupId { get; set; }
        
        public UserGroup UserGroup { get; set; }
      }
