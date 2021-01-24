    public class CustomButton : Button
    	{
    		public CustomButton() : base()
    		{
    			const int _animationTime = 10;
    			Clicked += async (sender, e) =>
    			{
    				try
    				{
    					var btn = (CustomButton)sender;
    					await btn.ScaleTo(1.2, _animationTime);
    					await btn.ScaleTo(1, _animationTime);
    				}
    				catch (Exception ex)
    				{
    					ex.Track();
    				}
    			};
    
    		}
    	}
