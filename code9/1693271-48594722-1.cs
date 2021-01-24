    using Xamarin.Forms;
    using Japanese;
    using Japanese.iOS;
    using Xamarin.Forms.Platform.iOS;
    using UIKit;
    
    [assembly: ExportRenderer(typeof(ExtStepper), typeof(ExtStepperRenderer))]
    namespace Japanese.iOS
    {
        public class ExtStepperRenderer : StepperRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Stepper> e)
            {
                base.OnElementChanged(e);
                ExtStepper s = Element as ExtStepper;
    
                if (Control != null)
                    Control.TintColor = s.StepperColor.ToUIColor();
    
            }
        }
    }
