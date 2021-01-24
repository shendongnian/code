    public class CommonFunctions
    {
    	public void DoSomeCommonThing(){
    		
    	}
    }
    
    public class CustomTextBox : TextBox 
    {
    	private CommonFunctions _commonFunctions;
    
        public CustomTextBox(CommonFunctions commonFunctions)
    	{
    			_commonFunctions = commonFunctions;
    	}
    }
    public class CustomNumericUpDown : NumericUpDown 
    {
    	private CommonFunctions _commonFunctions;
    
        public CustomNumericUpDown(CommonFunctions commonFunctions)
    	{
    			_commonFunctions = commonFunctions;
    	}
    }
