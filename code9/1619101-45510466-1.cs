    using System;
    using External;
    
    namespace Internal
    {
        class Program
        {
            static void Main(string[] args)
            {
                ExtensionMethods.IsNumeric(new object()); // (*)
                new object().IsNumeric(); // (**)
            }
        }
    }
    
    namespace External
    {
        public static class ExtensionMethods
        {
            [Obsolete]
            public static bool IsNumeric(this object o)
            {
                if (obj == null)
                  return false;
                return obj.GetType().IsPrimitive || obj is double || (obj is Decimal || obj is DateTime) || obj is TimeSpan;
            }
        }
    }
