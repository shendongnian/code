    public class PrimaryClass : Form
    {
        private int testValue;
        
    	public void PrimaryClassMethod()
    	{
    		Console.WriteLine("Method from Primary Class");
    	}
        public void UpdateTestValue (int val)
        {
            testValue = val;
        }
    }
    
    public class SecondaryClass : PrimaryClass
    {
    	public void CallPrimaryClassMethod()
    	{
    		this.PrimaryClassMethod();
            this.UpdateTestValue(10000);
    	}
    
    }
