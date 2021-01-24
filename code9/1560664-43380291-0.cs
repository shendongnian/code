    partial class Employee {
        private static readonly CompiledExpression<Employee,string> fullNameExpression
         = DefaultTranslationOf<Employee>.Property(e => e.FullName).Is(e => e.Forename + " " + e.Surname);
        private static readonly CompiledExpression<Employee,int> ageExpression
         = DefaultTranslationOf<Employee>.Property(e => e.Age).Is(e => DateTime.Now.Year - e.BirthDate.Value.Year - (((DateTime.Now.Month < e.BirthDate.Value.Month) || (DateTime.Now.Month == e.BirthDate.Value.Month && DateTime.Now.Day < e.BirthDate.Value.Day)) ? 1 : 0)));
    
      public string FullName {
        get { return fullNameExpression.Evaluate(this); }
      }
    
      public int Age {
        get { return ageExpression.Evaluate(this); }
      }
    }
