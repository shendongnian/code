    public class Student {
        
        public Student(string name) {
            Name = name;
            Infos = new List<Info>();
        }
        
        public string Name {get; set;}
    
        public ICollection<Info> Infos {get; set;}
    }
    public class Info {
        public Info(string course, int grade) {
            Course = course;
            Grade = grade;
        }
    
        public string Course { get; set; }
        public int Grade { get; set; }
    }
