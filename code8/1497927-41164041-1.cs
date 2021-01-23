    public abstract class Command
    {
         public static MoveCommand Move(IEnumerable<string> args) { .... }
         public static StopCommand Stop(IEnumerable<string> args) { .... }
         public abstract void Update();
         ...
    }
