	public class MyControl : ControlTemplate
	{
		static MyControl() 
		{
			// This tells WPF to search for a Style for this type
			DefaultStyleKeyProperty.OverrideMetadata(typeof(MyControl)), 
                new FrameworkPropertyMetadata(typeof(MyControl)));
		}
	}
