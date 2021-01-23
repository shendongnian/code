    public static class StaticClass {
         public interface IInstance {
             int Value { get; set; }
         }
         private class InstanceClass: IInstance {
             public int oldValue;
             public Value { get; set; }
         }
         // Static class becomes responsible for handing out `IInstance` objects
         public static IInstance GetInstance() {
             return new InstanceClass();
         }
         public static void Backup(IInstance i) {
             if (i is InstanceClass ic) {
                 ic.oldValue = ic.Value;
             }
             else {
                 throw new InvallidOperationException("Can only Backup IInstance objects that were created by GetInstance");
             }
         }
         public static void Restore(IInstance i) {
             if (I is InstanceClass ic)
             {
                 ic.Value = ic.oldValue;
             }
             else {
                 throw new InvallidOperationException("Can only Restore IInstance objects that were created by GetInstance");
             }
         }
