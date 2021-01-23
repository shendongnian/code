    public abstract class Command
    {
         public static Command Move(IEnumerable<int> args) => new MoveCommand(args);
         public static Command Stop(IEnumerable<int> args) => new StopCommand(args);
         public abstract void Update();
         ...
         private class MoveCommand: Command 
         {
             public MoveCommand(IEnumerable<int> args)
             {
                 var argumentCount = args.Count();
                 if (argumentCount  != 2)
                     throw new SyntaxErrorExcpetion("Invalid number of arguments in Move command. Expected 2, recieved {argumentCount}.");
                 //Construction logic follows
                 ....
             }
         }
         private class StopCommand: Command { ... }
    }
