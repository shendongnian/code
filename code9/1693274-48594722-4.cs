    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    using Japanese;
    using Japanese.Droid;
    using Android.Content;
    using Android.Graphics;
    
    [assembly: ExportRenderer(typeof(ExtStepper), typeof(ExtStepperRenderer))]
    namespace Japanese.Droid
    {
        public class ExtStepperRenderer : StepperRenderer
        {
            public ExtStepperRenderer(Context context) : base(context)
            {
            }
    
            protected override void OnElementChanged(ElementChangedEventArgs<Stepper> e)
            {
                base.OnElementChanged(e);
                ExtStepper s = Element as ExtStepper;
    
                if (Control != null)
                {
                    Control.GetChildAt(0).Background.SetColorFilter(s.StepperColor.ToAndroid(), PorterDuff.Mode.Multiply);
                    Control.GetChildAt(1).Background.SetColorFilter(s.StepperColor.ToAndroid(), PorterDuff.Mode.Multiply);
                }
                
    
            }
        }
    }
