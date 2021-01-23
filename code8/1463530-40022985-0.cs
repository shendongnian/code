    [BirthDateAttribute]
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    public System.DateTime BirthDate { get; set; }
       public class BirthDateAttribute : RangeAttribute
       {
          public BirthDateAttribute()
            : base(typeof(DateTime), 
              DateTime.Now.AddYears(-120).ToShortDateString(), 
              DateTime.Now.AddDays(-1)ToShortDateString()) { } 
       }
