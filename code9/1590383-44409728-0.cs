    public class EmployeeWeekViewModel{
      public string EmployeeName{get;set;}
      public WeekViewModel Week1 {get;set;}
      public WeekViewModel Week2 {get;set;}
      ...
      public WeekViewModel Week20 {get;set;}
    }
    
    public class WeekViewModel{
      public int Id{get;set;}
      public string Color{get;set;}
      public string Symbol{get;set;}
    }
    
    employeesList.Select(t=> new EmployeeWeekViewModel(){
      EmployeeName = t.Name,
      Week1 = weeksList.FirstOrDefault(w => w.id == t.Week1).Select(w => new WeekViewModel(){
        Id = w.id,
        Color = w.color,
        Symbol = w.symbol
      }),
      Week2 = weeksList.FirstOrDefault(w => w.id == t.Week2).Select(w => new WeekViewModel(){
        Id = w.id,
        Color = w.color,
        Symbol = w.symbol
      }),
      ...
    });
