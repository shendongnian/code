    public class Folder
    {
        [Key]
        public int Id { get; set; }
    
        // Some Property
        public string Name { get; set; }
    
        // They foreignkey for Many-side
        public virtual Folder Parent { get; set; }
    
        // The list for One-side (Not tested in my application)
        public virtual ICollection<Folder> SubFolders { get; set; }
    }
