    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        public string LinkName { get; set; }    
         public int ProjectId { get; set; }
        public virtual Project projects { get; set; }
    }
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public virtual ICollection<Link> links { get; set; }
    }
