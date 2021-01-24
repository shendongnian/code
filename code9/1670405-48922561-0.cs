    public class PhysicalObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int StorageRequestId { get; set; }
        public string Title { get; set; }
        public virtual PhysicalObject Parent { get; set; }
        public virtual ICollection<PhysicalObject> SubPhysicalObjects { get; set; }
        public virtual StorageRequest StorageRequest { get; set; }
        
    }
    public class StorageRequest
    {
        public StorageRequest()
        {
            PhysicalObjects = new HashSet<PhysicalObject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<PhysicalObject> PhysicalObjects { get; set; }
    }
    
