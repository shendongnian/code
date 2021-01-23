    public class Details
    {
        public string Study;
        public string Location;
        public string[] Friends;
    }
    public class Student
    {
      public string Name;
      public Details StudDetails;
      public string Address;  
      public override bool Equals(Object obj) 
      {
      // Check for null values and compare run-time types.
      if (obj == null || GetType() != obj.GetType()) 
       return false;
    
      Student s = (Student)obj;
      return (Name == s.Name) && (Address == s.Address);
      }
    }
    
    Student a = new Student();
    a.Name = "john";
    a.Address ="CA";                        
    //a.StudDetails.Location = "LA";
    //a.StudDetails.Study = "MBA";
    //a.StudDetails.Friends = new string[] { "X", "Y"};
    Student b = new Student();
    b.Name = "john";
    b.Address = "CA";
    //b.StudDetails.Location = "LA";
    //b.StudDetails.Study = "MBA";
    //b.StudDetails.Friends = new string[] { "X", "Y"};
    bool x = a.Equals(b);
    Console.WriteLine( x );
