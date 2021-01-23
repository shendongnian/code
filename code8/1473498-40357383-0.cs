    public static class StaticClass 
    {
      private interface IInstanceClassInternal
      {
        int OldValue { get; set; }
      }
    
      public sealed class InstanceClass : IInstanceClassInternal 
      {
        int IInstanceClassInternal.OldValue { get; set; }
        
        public int Value;
      }
    
      public static void Backup(InstanceClass ic)
      {
        ((IInstanceClassInternal)ic).OldValue = ic.Value;
      }
    
      public static void Restore(InstanceClass ic) 
      {
        ic.Value = ((IInstanceClassInternal)ic).OldValue;
      }
    }
