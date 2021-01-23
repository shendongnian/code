    public class BirthDateAttribute : RangeAttribute {
       public BirthDateAttribute() 
                       : base(
                               typeof(DateTime), 
                               DateTime.Now.AddYears(-120).ToShortDateString(), 
                               DateTime.Now.AddDays(-1)ToShortDateString()
                         ) { } 
    }
