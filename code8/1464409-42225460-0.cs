    public class Student
    {
        // Collections should be encapsulated!
        private readonly ICollection<Course> courses;
    
        // Expose constructors that express how students can be created.
        // Notice that this constructor calls the default constructor in order to initialize the courses collection.
        public Student(string firstName, string lastName, int studentNumber) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            StudentNumber = studentNumber;
        }
    
        // Don't allow this constructor to be called from code.
        // Your persistence layer should however be able to call this via reflection.
        private Student()
        {
            courses = new List<Course>();
        }
    
        // This will be used as a primary key. 
        // We should therefore not have the ability to change this value. 
        // Leave that responsibility to the persistence layer.
        public int Id { get; private set; }
    
        // It's likely that students names or numbers won't change, 
        // so set these values in the constructor, and let the persistence 
        // layer populate these fields from the database.
        public string FirstName { get; private set; }
        public string LastName {get; private set; }
        public int StudentNumber { get; private set; }
    
        // Only expose courses via something that is read-only and can only be iterated over.
        // You don't want someone overwriting your entire collection.
        // You don't want someone clearing, adding or removing things from your collection.
        public IEnumerable<Course> Courses => courses;
    
        // Define methods that describe semantic behaviour for what a student can do.
        public void Subscribe(Course course)
        {
            if(courses.Contains(course))
            {
                throw new Exception("Student is already subscribed to this course");
            }
    
            courses.Add(course);
        }
    
        public void Ubsubscribe(Course course)
        {
            courses.Remove(course);
        }
    }
