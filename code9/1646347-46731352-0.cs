    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace StringFunctions.Extensions
    {
       public static class StringExtensions 
        {
            public static readonly string Space = " ";
    
            public static string  Spacemethod(this string name)
            {
                return string.Concat(name," ");
            }
        }
    }
