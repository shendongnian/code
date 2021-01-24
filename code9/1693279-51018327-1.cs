	public class StepperExtendRenderer : StepperRenderer
	{
		StepperExtend FormElement
		{
			get { return Element as StepperExtend; }
		}
		protected override void OnElementChanged(ElementChangedEventArgs<Stepper> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
			{
				UpdateColor();
			}
		}
		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == StepperExtend.ColorProperty.PropertyName)
			{
				UpdateColor();
			}
			else
			{
				base.OnElementPropertyChanged(sender, e);
			}
		}
		private void UpdateColor()
		{
			Control.GetChildAt(0).Background.SetColorFilter(FormElement.Color.ToAndroid(), PorterDuff.Mode.Multiply);
			Control.GetChildAt(1).Background.SetColorFilter(FormElement.Color.ToAndroid(), PorterDuff.Mode.Multiply);
		}
	}
