    public class ResumeVM
    {
        public ResumeVM()
        {
            Resume = new List<Resume>();
            Experience = new List<Experience>();
        }
        public List<Resume> Resume { get; set; }
        public List<Experience> Experience { get; set; }
    }
