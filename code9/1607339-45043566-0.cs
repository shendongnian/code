    public static ValidationHelper
    {
      public static void ValidateIsNumeric(string value)
      {
        if(value is not Number){
          print "Wrong cell value";
        }
      }
    }
