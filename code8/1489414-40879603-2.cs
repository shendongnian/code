    public class student
     {
         public int id { get; set; }
         public String fName { get; set; }
         public String lName { get; set; }
    
         public override string ToString()
         {
             return String.Format("Student ID : {0} \n Full Name : {1} {2}", id, fName, lName);
         }
     }
