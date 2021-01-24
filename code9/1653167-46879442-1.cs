    public interface IStudent
    {
         string DisplayInformation();
    }
    public class Student : IStudent
    {
        public string Name { get; set; }
    
        public string Grade { get; set; }
    
        public int Age { get; set; }
    
        public string DisplayInformation()
        {
            return $"{Name} - {Age} years old is in {Grade} grade";
        }
    }
    public class ScienceStudentDecorator : IStudent
    {
        public string Labs { get; set; }
        private IStudent _student;
        public ScienceStudentDecorator(IStudent student)
        {
            _student = student;
        }
    
        public string DisplayInformation()
        {
            var info =  _student?.DisplayInformation();
            return $"{info}. Labse are {Labs}";
        }
    }
