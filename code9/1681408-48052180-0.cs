     public static T Clone<T>(T source)
         where T: class 
     {
          if (source is GameObject)
          {
              return (T)(object)Instantiate((GameObject)source);  
          }
          else ...
      }
