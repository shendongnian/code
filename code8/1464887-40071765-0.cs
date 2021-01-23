    public class ContentEntityRef : BaseModel
    {
        public ContentEntityRef()
        {
            RoleRefs = new HashSet<RoleRef>();
        }
        public int EntityId { get; set; }
        public string EntityName { get; set; }
        public int? ParentEntityId { get; set; }
        public virtual ICollection<RoleRef> RoleRefs { get; set; }
        public virtual ContentEntityRef Parent { get; set; }
        public virtual ICollection<ContentEntityRef> Children { get; set; }
    }
