    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var s = new Student {
    			StudentId = 1,
    			Name = "Alex"
    		};
    		
    		var s2 = new Student(s);
    		
    		Console.WriteLine(s2.StudentId);
    		Console.WriteLine(s2.Name);
    	}
    }
    
    class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
    
    	public Student() {}
    	
        public Student(Student student)
        {
            StudentId = student.StudentId;
            Name = student.Name;
        }
    }
