    using System;
    
    public class CommandLine
    {
       public static void Main(string[] args)
       {
           for(int i = 0; i < args.Length; i++)
           {
               if( args[i] == "-Google" )
               {
                   // do something
               }
           }
       }
    }
