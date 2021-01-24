    public class Class
    {
        public int Id { get; set; }
    
        [Required]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
    
    public class ClassModel
    {
        public int Id { get; set; }
    
        [Required]
        public int SkillId { get; set; }
        
        public string SelectedSkills { get; set; }
    
        public int Repeat { get; set; }
    } 
