    public interface IStudent //this would rather be called an IInformationDisplayer
    {
         string DisplayInformation();
    }
    public class Student : IStudent
    {
        public string Name, Grade, Age, etc... { get; set; }
        private IStudent _student = null;
        public Student() { }
        public Student(IStudent student) {  _student = student; }
        public string DisplayInformation()
        {
            return $"{_student?.DisplayInformation()}" + 
                   $"{Name} - {Age} years old is in {Grade} grade";
        }
    }
    public class ScienceStudent : IStudent //it's still a decorator
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
