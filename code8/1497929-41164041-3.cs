    public abstract class Command
    {
         public static Command Move(IEnumerable<string> args) => new MoveCommand(args);
         public static Command Stop(IEnumerable<string> args) => new StopCommand(args);
         public abstract void Update();
         ...
         private class MoveCommand: Command { ... }
         private class StopCommand: Command { ... }
    }
