    public class PopupView : ContentView
    	{
    		//public readonly View Content;
    
    		public PopupView(View content)
    		{
    			if (content == default(View))
    			{
    				throw new ArgumentNullException(nameof(content));
    			}
    			Content = content;
    		}
    	}
