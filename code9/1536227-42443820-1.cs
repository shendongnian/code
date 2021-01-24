    namespace MultipleBrowserTest
    {
        public class Browsers_Reflection
        {       
            public Browsers_Reflection(Type type)
            {
                Driver = (IWebDriver)Activator.CreateInstance(type);
            }
            private IWebDriver Browser { get; set; }
    
            public IWebDriver Driver
            {
                get {
                    if (Browser == null)
                        throw new NullReferenceException(
                            "The WebDriver browser instance was not initialized.");
                    return Browser;
                }
                set { Browser = value; }
            }
        }
    }
