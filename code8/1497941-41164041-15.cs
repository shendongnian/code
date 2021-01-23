    public abstract class Command
    {
         private const int validMoveArgumentCount = 2;
         private const int validStopArgumentCount = 1;
         public static Command Move(IEnumerable<int> args)
         {
             var arguments = args.ToArray();
             var argumentCount = arguments.Length;
             if (argumentCount != validMoveArgumentCount)
                 throw new SyntaxErrorExcpetion("Invalid number of arguments in Move command. Expected 2, recieved {argumentCount}.");
             return new MoveCommand(arguments[0], arguments[1]);
         }
         public static Command Stop(IEnumerable<int> args)
         {
             var arguments = args.ToArray();
             var argumentCount = arguments.Length;
             if (argumentCount != validStopArgumentCount)
                 throw new SyntaxErrorExcpetion("Invalid number of arguments in Stop command. Expected 1, recieved {argumentCount}.");
             return new StopCommand(arguments[0]);
         }
         public abstract void Update();
         ...
         private class MoveCommand: Command { ... }
         private class StopCommand: Command { ... }
    }
