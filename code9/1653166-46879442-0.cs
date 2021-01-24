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
    
        public ScienceStudentDecorator(IStudent student)
        {
        }
    
        public string DisplayInformation()
        {
            var info =  base.DisplayInformation();
            return $"{info}. Labse are {Labs}";
        }
    }
