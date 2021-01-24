    public interface MyInterface : IDependency
    {
       void DoSomething();
    }
    public MyClass : MyInteface
    {
       public void DoSomething()
       {
          // work
       }
    }
    public class ISRelatedContentsDriver : ContentPartDriver<ISRelatedContentsPart>
    {
        private readonly IContentManager _contentManager;
        private readonly IMyInterface _myInterface;
    
        public ISRelatedContentsDriver(IContentManager contentManager, IMyInterface myInterface)
        {
            _contentManager = contentManager;
            _myInterface = myInterface;
        }
    }
