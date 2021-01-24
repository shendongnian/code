    using System;
    using System.Runtime.CompilerServices;
    
    namespace ConsoleApp3
    {
        class Program
        {
            static void Main(string[] args)
            {
                Logger.WriteLog("Hello");
            }
    
        }
        public class Logger
        {
            public static void WriteLog(string msg, [CallerMemberName] string methodName="")
            {
                Console.WriteLine("Method:{0}, Message: {1}",methodName,msg);
            }
        }
    }
