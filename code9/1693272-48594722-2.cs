    using Xamarin.Forms;
    
    namespace Japanese
    {
        public class ExtStepper : Stepper
        {
    
            public static readonly BindableProperty ColorProperty =
       BindableProperty.Create(nameof(Color),
           typeof(Color), typeof(ExtStepper),
           Color.Default);
            
            public Color StepperColor
            {
                get { return (Color)GetValue(ColorProperty); }
                set { SetValue(ColorProperty, value); }
            }
    
        }
    }
