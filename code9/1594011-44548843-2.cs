    public class SomeTest : CommonSteps 
    {
        public SomeTest()
           :base()
        {
           //Constructor
        }
    
        [Test]
        public void checkFields()
        {
            //Instantiate your OrderPage object in a CommonMethods class 
            //you would also instantiate and set up your Validation/Report objects 
            //so they could be passed down through the page objects
           //You would also open the browser, basically any before and after test 
           //set up in the CommonMethods class
           //Your test class would then inherit the CommonMethods class and it 
           //would start at the test itself.
        
            //oPage is declared in CommonMethods
            oPage.validateField("Smith");
        
        }
    }
