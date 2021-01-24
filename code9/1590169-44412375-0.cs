    public class GameCocosSharpView : View
    	{
    	   public int WedgeRating
    		{
    			get { return (int)GetValue(WedgeRatingProperty); }
    			set { SetValue(WedgeRatingProperty, value); }
    		}
    		public static void WedgeRatingChanged(BindableObject bindable, object oldValue, object newValue)
    		{
    			
    		}
    		public static readonly BindableProperty WedgeRatingProperty =
    			BindableProperty.Create("WedgeRating", typeof(int), typeof(GameCocosSharpView), 1, BindingMode.Default, null, WedgeRatingChanged);
    
    	}
