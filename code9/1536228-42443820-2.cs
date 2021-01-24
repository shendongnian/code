    namespace MultipleBrowserTest
    {
        public class Browsers_UnityContainer
        {
            public Browsers_UnityContainer(Type type)
            {
                _unityContainer.RegisterType(typeof(IWebDriver), type, Guid.NewGuid().ToString());
                _unityContainer.RegisterInstance(Browser);
            }
    
            private IWebDriver Browser { get; set; }
            private readonly UnityContainer _unityContainer = new UnityContainer();
    
            public IWebDriver Driver
            {
                get { return Browser; }
                set { Browser = value; }
            }
        }
    }
