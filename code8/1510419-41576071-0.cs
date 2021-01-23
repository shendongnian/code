     public class BaseClass
        {      
          private DateTime? _dc;  //notice, it's nullable
          public DateTime DateCreated 
              {
                  get 
                  {
                     if(_dc == null)
                        _dc = InitDate();
                     return (DateTime)_dc;
                  }
                  set
                  { _dc = value; }
                  
              }
           private static DateTime InitDate()
           { return DateTime.Now; }
      }
        
      public class DerivedClass : BaseClass
      {
          public DerivedClass
          {           
          }
      }
