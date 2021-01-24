     public class Project
     {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int ApplicationUserId{ get; set;}
        public virtual ApplicationUser ApplicationUser { get; set; }
     }
