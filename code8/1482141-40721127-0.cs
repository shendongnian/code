    namespace Extension
    { 
    static class MyIntMethods
      {
        public static bool Between(this int value,int min, int max)
        {
            return (value > min && value < max) ? true : false;
        }
      }
    }
