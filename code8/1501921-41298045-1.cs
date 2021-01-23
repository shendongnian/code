    public class StudentPageModel
        {
            public int SchoolYear { get; private set; }
            public Student Student { get; private set; }
    
            public Class Class { get; private set; }
    
            public StudentPageModel(int schoolYear, Student student, Class studentClass)
            {
                SchoolYear = schoolYear;
                Student = student;
                Class = studentClass;
            }
        }
