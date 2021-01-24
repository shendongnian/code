     public static T Clone<T>(T source)
     {
          if (source is GameObject)
          {
              return (T)(object)Instantiate((GameObject)(object)source);  
          }
          else ...
      }
