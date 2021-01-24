    public class Target
    {
        // My target method. 
        public void Run(string arg0, string arg1)
        {
            Console.WriteLine("Run method body");
        }
    }
    public static class Trace
    {
        // This is my log method, which i want to call in begining of Run() method. 
        public static void LogEntry(string methodName, object[] parameters)
        {
            Console.WriteLine("******Entered in " + methodName + " method.***********");
            Console.WriteLine(parameters[0]);
            Console.WriteLine(parameters[1]);
        }
    }
