    public class SomeBusinessLogic // defined in your *BL* project
    {
      public SomeBusinessLogic(SomeDependency someDependency)
      {
      }
    }
    var someBusinessLogic = DependencyResolver.Current.GetService<SomeBusinessLogic>(); // in your *FRONTEND* project
