        // Returns this option's value from args, or null on error
        public string OptionValue(string[] args, string option)
        {
            try
            {
                if (args.Contains(option))
                {
                    string value = args[args.IndexOf(option) + 1];  // reuse expressions as well
                    if (!value.StartsWith("-"))
                        return value;
                }
    
                return null;    // null meaning "undefined"
            }
            catch
            {
                return null;  
            }
         }
         // And now your code
         string[] args = Environment.GetCommandLineArgs();
         string Arg1 = OptionValue(args, "-r"); 
         string Arg2 = OptionValue(args, "-n"); 
         string Arg3 = OptionValue(args, "-p"); 
         bool isCmdLineWrong = (Arg1 == null ||
                                Arg2 == null ||
                                Arg3 == null);
      
