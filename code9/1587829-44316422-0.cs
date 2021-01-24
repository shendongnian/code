    #define DEBUG  
    //#define TRACE  
    #undef TRACE  
    
    using System;  
    
    public class TestDefine  
    {  
      static void Main()  
       {  
         #if (DEBUG)  
           Console.WriteLine("Debugging is enabled.");  
         #endif  
         #if (TRACE)  
           Console.WriteLine("Tracing is enabled.");  
         #endif  
       }  
     }  
    // Output:  
    // Debugging is enabled.  
