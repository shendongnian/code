    [assembly: ExportRenderer(typeof(NumericEntry), typeof(NumericEntryRenderer))]
    namespace Forms_PCL_Tester.iOS
    {
    	public class NumericEntryRenderer : EntryRenderer
    	{
    		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
    		{
    			base.OnElementChanged(e);
    			if (e.NewElement != e.OldElement)
    				if (Control != null)
    				{
    					Control.KeyboardType = UIKeyboardType.NumbersAndPunctuation;
    					Control.ShouldChangeCharacters += (UITextField textField, NSRange range, string replacementString) =>
    					 {
    						 foreach (var aChar in replacementString)
    							 if (!NSCharacterSet.DecimalDigits.Contains(aChar))
    								 return false;
    						 return true;
    					 };
    				}
    		}
    	}
    }
