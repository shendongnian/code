      class Program {
        static void Main(string[] args) {
          var categories = new TEST<Categories>().GetSomeItemsDependentSomehowOnT();
          var users = new TEST<Users>().GetSomeItemsDependentSomehowOnT();
    
          Console.WriteLine();
          Console.ReadKey();
        }
    
    
        public class Categories { }
        public class Users { }
    
        public class TEST<TModel> {
          public IEnumerable<dynamic> GetSomeItemsDependentSomehowOnT() {
            switch (typeof(TModel).Name) {
              case "Users":
                return new[] { new Users() };
              case "Categories":
                return Enumerable.Empty<Categories>();
              default:
                break;
            }
    
            throw new ArgumentException("Unknown type.");
          }
        }
      }
