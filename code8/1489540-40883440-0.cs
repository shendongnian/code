    public static class CommandLine {
      private static String FindValue(string value) {
        var commandArguments = Environment.GetCommandLineArgs();
        int index = commandArguments.IndexOf(value);
        if (index < 0)
          return null; 
        else if (index >= commandArguments.Length - 1)
          return null; // cmd like "myRoutine.exe -p" 
        else 
          return commandArguments[index + 1];  
      } 
      static CommandLine() {
        Arg1 = FindValue("-r");
        Arg2 = FindValue("-n");
        Arg3 = FindValue("-p");
      } 
      public static String Arg1 { get; private set; }
      
      public static String Arg2 { get; private set; }
      public static String Arg3 { get; private set; }
      public static bool IsValid {
        get {
          return Arg1 != null && Arg2 != null && Arg3 != null;
        }
      }
    }
