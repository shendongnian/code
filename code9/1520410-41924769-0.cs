      internal class Program
      {
        private static void Main()
        {
          var mock = Substitute.For<SomeClass>();
          var mi = mock.GetType().GetTypeInfo()
            .GetMethod("SomeMethod", BindingFlags.NonPublic | BindingFlags.Instance);
    
          mi.Invoke(mock, null).Returns("xxxxXXX");
    
          Console.WriteLine(mi.Invoke(mock, null)); // -> Write xxxxXXX
        }
      }
    
      public class SomeClass
      {
        protected virtual string SomePropertyName { get; set; }
    
        protected virtual string SomeMethod() => "aaa";
      }
