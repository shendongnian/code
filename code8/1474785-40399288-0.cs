    public interface IUniversityMember
    {
       //... here common fields between `Teacher` and `Student`
       string Name{ get; set;}
       string Gender { get; set;}
    }
    
    //after that
    
    public interface IStudent
    {
        int GetGPA();
        int CreditsToPass {get; set;}
    }
    
    public interface ITeacher
    {
       int WorkedHours {get; set;}
       decimal PayPerHour {get; set;}
    }
    
    public class BiologicalStudent: IUniversityMember, IStudent
    {
        public int CreditsToPast {get; private set;}
        
        public BiologicalStudent ()
        {
            CreditsToPast  = 5;
        }
        //stuff
        public int GetGPA()
        {
            return 3;
        }
    }
    
    public class MathStudent: IUniversityMember, IStudent
    {
        public int CreditsToPast {get; private set;}
        
        public BiologicalStudent ()
        {
            CreditsToPast  = 9;
        }
        public int GetGPA()
        {
            return 2;
        }
    }
    
    public class BiologicalTeacher: IUniversityMember, ITeacher
    {
         public int WorkedHours { get; set;}
         public decimal PayPerHour {get; private set;}
         public MathTeacher()
         {
             PayPerHour = 8;
             
         }
    }
    
    public class MathTeacher: IUniversityMember, ITeacher
    {
         public int WorkedHours { get; set;}
         public decimal PayPerHour {get; private set;}
         public MathTeacher()
         {
             PayPerHour = 10;
             
         }
    }
    //Now if you have a university class
    
    public class OxfordUniversity:IUniversity //can inherit interface too
    {
         public decimal PaySallary(ITeacher teacher)
         {
              return teacher.WorkedHours*teacher.PayPerHour;
         }
    
         public bool CheckForSchollarship(IStudent student)
         {
             //do some checks
             int gpa = student.Get
         }
    }
