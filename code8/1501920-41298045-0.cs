    public class StudentService : IStudentService
        {
    
            private readonly IStudentRepository studentRepository;
            private readonly IClassRepository classRepository;
    
            public StudentService(IStudentRepository studentRepository, IClassRepository classRepository)
            {
                if (studentRepository == null) throw new ArgumentNullException(nameof(studentRepository));
                if (classRepository == null) throw new ArgumentNullException(nameof(classRepository));
    
                this.studentRepository = studentRepository;
                this.classRepository = classRepository;
            }
    
            public void Save(Student student, Class studentsClass)
            {
                if (student == null) throw new ArgumentNullException(nameof(student));
                if (studentsClass == null) throw new ArgumentNullException(nameof(studentsClass));
    
                studentRepository.Save(student);
                classRepository.Save(studentsClass);
            }
        }
