    public class Student
    {
      public string ID
      public List<double> TestScores {get;set;}
      // in this case average only has a getter which calculates the average when needed.
      public double Average 
      {
          get
          { 
           if(TestScores != null && TestScores.Count >0)
             {
               double ave = 0;
               foreach(var x in TestScores)//basic average formula.
                  ave += x;
               return ave/TestScores.Count;
             }
             return 0; // can't divide by zero.
          }
      }
      public Student(string id)
      {
       ID = id;
       TestScores = new List<double>();
      }
    }
