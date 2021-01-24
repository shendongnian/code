    public class Test {
        public Test() {
            if (Test.ChildGeneratedClass.DelegateInstance != null)
                return;
            Test.ChildGeneratedClass.DelegateInstance = 
                Test.ChildGeneratedClass.Instance.DelegateFunc;
        }
        public void WriteFirstLine() {
            Console.WriteLine("Object allocated...");
        }
        public void WriteSecondLine() {
            Console.WriteLine("Object deallocated. Press any button to exit.");
        }
        [CompilerGenerated]
        [Serializable]
        private sealed class ChildGeneratedClass {
            // this is what's called Test.<c> <>9 in your snapshot
            public static readonly Test.ChildGeneratedClass Instance;
            // this is Test.<c> <>9__0_0
            public static Func<object, bool> DelegateInstance;
            static ChildGeneratedClass() {
                Test.ChildGeneratedClass.Instance = new Test.ChildGeneratedClass();
            }
            internal bool DelegateFunc(object _) {
                return true;
            }
        }
    }
