    public class Employee
    {
         public int ID {get;set;}
         public string Name {get;set;}
         public List<DateTime> DaysIWasOut {get;set;}
    }
    
    public static int TimeOut(IEnumerable employees)
    {     
           int totalOutInstances = 0;
           DataTable dt = HolidaysPlease(); //this refers to another method
           //to fill the table.  Just a basic SQLAdapter.Fill kind of thing. 
           //Basic so I won't waste time on it here.
           foreach(var e in employees)
           {
             var holidays = dt.AsEnumerable().Where(t => Convert.ToDateTime(t[3]) == d)        //holidays now has all of the holidays the employee had off. 
             totalOutInstances = e.DaysIWasOut.Count();
             foreach(var d in e.DaysIWasOut)
             {
                int daystolook = 0;
                if (d.DayOfWeek == DayOfWeek.Friday)
                   daystolook +=3;
                else
                   daystolook +=1;
                if(e.DaysIWasOut.Contains(d.AddDays(daystolook))                        
                       {totalOutInstances --; } //don't count that day               
             }
        
        }
     return totalOutInstances;
    }
