    // Contains all arguments for the add command
    class AddArgs {
     bool Verbose;
     bool IgnoreErrors;
     IEnumerable<string> Files;
    }
    
    // Contains all arguments for the remove command
    class RemoveArgs {
     bool Verbose;
     IEnumerable<string> Files;
    }
    // entry point into console app
    static void Main(string[] args) {
     var fclp = new FluentCommandLineParser();
    
    // use new SetupCommand method to initialise a command
     var addCmd = fclp.SetupCommand<AddArgs>("add")
                      .Callback(args => Add(args)); // executed when the add command is used
    
    // the standard fclp framework, except against the created command rather than the fclp itself
     addCmd.Setup(args => args.Verbose)
           .As('v', "verbose")
           .SetDefault(false)
           .WithDescription("Be verbose");
    
     addCmd.Setup(args => args.IgnoreErrors)
           .As("ignore-errors")
           .SetDefault(false)
           .WithDescription("If some files could not be added, do not abort");
    
     addCmd.Setup(args => args.Files)
           .As('f', "files")
           .Description("Files to be tracked")
           .UseForOrphanArguments();
    
    // add the remove command
     var removeCmd = fclp.SetupCommand<RemoveArgs>("rem")
                         .Callback(args => Remove(args)); // executed when the remove command is used
    
     removeCmd.Setup(args => args.Verbose)
              .As('v', "verbose")
              .SetDefault(false)
              .WithDescription("Be verbose");
    
     removeCmd.Setup(args => args.Files)
              .As('f', "files")
              .WithDescription("Files to be untracked")
              .UseForOrphanArguments();
    
     fclp.Parse(args);
    }
    
    void Add(AddArgs args){
      // add was executed
    }
    
    void Remove(RemoveArgs args){
      // remove was executed
    }
