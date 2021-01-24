    	public class StepperExtend : Stepper
	{
		public static readonly BindableProperty ColorProperty =
			BindableProperty.Create(
				nameof(Color),
				typeof(Color),
				typeof(StepperExtend),
				Color.Default);
		public Color Color
		{
			get { return (Color)GetValue(ColorProperty); }
			set { SetValue(ColorProperty, value); }
		}
	}
