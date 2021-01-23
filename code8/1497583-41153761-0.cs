    public class MainClass: Form
    {
        private int testValue;
    
        public MainClass()
        {
            testValue = 0;
        }
    
        public void updateTestValue (int val)
        {
            testValue = val;
        }
    }
    
    public class SecondaryClass : MainClass
    {
        public SecondaryClass() 
        {
    
        }
    
        private void button1_click(Object sender, EventArgs e)
        {
            // I want to be able to do this:
            updateTestValue(100);
        }
    }
