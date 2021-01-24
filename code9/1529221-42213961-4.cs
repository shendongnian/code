    public class Course
    {
        public int ID { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public List<Module> Modules { get; set; }
        public Course()
        {
            this.Modules = new List<Module>();
        }
    }
    public class Module
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
