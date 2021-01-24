    public interface IStudent
    {
    	string Name {get;}
    	
    	string DisplayInformation();
    }
    
    public class Student : IStudent
    {
        public string Name { get; set; }
    
        public string DisplayInformation()
        {
            return $"{Name} - {Age} years old is in {Grade} grade";
        }
    }
    
    
    
    /// Base for decorators which stores our base in constructor
    /// Gives default behaviour to all props and methods required by Interface
    public abstract class StudentDecorator : IStudent
    {
    	protected IStudent BaseStudent {get;}
    	
    	protected StudentDecorator(IStudent student)
    	{
    		BaseStudent = student;
    	}
    	
    	public virtual string Name { get { return BaseStudent.Name;} }
    
    	public virtual string DisplayInformation()
    	{
    		return BaseStudent.DisplayInformation();
    	}
    
    /// Concrete decorator, we don't need to override Name property
    public class ScienceStudentDecorator : StudentDecorator
    {
        public string Labs { get; set; }
    
        public ScienceStudentDecorator(IStudent student) : base (student)
        {
    		///Behaviour here done by abstract constructor
        }
    
        public override string DisplayInformation()
        {
            var info =  BaseStudent?.DisplayInformation();
            return $"{info}. Labse are {Labs}";
        }
    }
