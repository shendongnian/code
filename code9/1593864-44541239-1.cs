    public class PowerManager : IDisposable
    {
      [Flags]
      public enum ExecutionStateEnum : uint
      {
        LetTheSystemDecide    = 0x00,
        SystemRequired        = 0x01,
        SystemDisplayRequired = 0x02,
        UserPresent           = 0x04,
        Continuous            = 0x80000000,
      }
      [DllImport("kernel32")]
      private static extern uint SetThreadExecutionState(ExecutionStateEnum esFlags);
      public PowerManager() {}
      public Update(ExecutionStateEnum state)
      {
        SetThreadExecutionState(state);
      }
    }
