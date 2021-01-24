    internal class Program
    {
        private static void Main( string[] args )
        {
            var SomeObject = new FakeClass();
            SomeObject.SomeDelegateProperty?.Invoke( someOtherDelegate() );
        }
        public static string someOtherDelegate()
        {
            return String.Empty;
        }
        public class FakeClass
        {
            public Action<string> SomeDelegateProperty;
        }
    }
