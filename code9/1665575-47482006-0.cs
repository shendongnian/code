    [assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
    namespace MyApp.Droid
    {
    	public class CustomButtonRenderer : ButtonRenderer
    	{
            public CustomButtonRenderer(Context context) : base(context)
            {
                
            }
    
    		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    		{
    			base.OnElementPropertyChanged(sender, e);
    			//ToDo: Customize Button
    		}
    	}
    }
