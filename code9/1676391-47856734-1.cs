    public class CommonFunctions
    {
    	public void ValidateInput(Object sender){
    		// do your validation logic
    	}
    }
    
    public class CustomTextBox : TextBox 
    {
    	private CommonFunctions _commonFunctions;
    
        public CustomTextBox(CommonFunctions commonFunctions)
    	{
    			_commonFunctions = commonFunctions;
    	}
     
        private void Control_TextChanged(Object sender,EventArgs e)
        {
                  _commonFunctions.ValidateInput(sender);
        }
    }
    public class CustomNumericUpDown : NumericUpDown 
    {
    	private CommonFunctions _commonFunctions;
    
        public CustomNumericUpDown(CommonFunctions commonFunctions)
    	{
    			_commonFunctions = commonFunctions;
    	}
        private void Control_TextChanged(Object sender,EventArgs e)
        {
                  _commonFunctions.ValidateInput(sender);
        }
    }
