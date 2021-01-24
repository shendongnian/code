    namespace CustomValidation
    {
    	public class MyValidator : CustomValidator
    	{
    		protected override bool OnServerValidate(string value)
    		{
    			bool baseresult = base.OnServerValidate(value);
    			if (baseresult && value == "TestValue")
    				return true;
    
    			return false;
    		}
    
    		protected override void AddAttributesToRender(HtmlTextWriter writer)
    		{
    			base.AddAttributesToRender(writer);
    		}
    
    		protected override bool ControlPropertiesValid()
    		{
    			return base.ControlPropertiesValid();
    		}
    
    		protected override bool EvaluateIsValid()
    		{
    			return base.EvaluateIsValid();
    		}
    	}
    }
