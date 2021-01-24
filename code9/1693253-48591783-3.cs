    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    
    using CustomStepper;
    using CustomStepper.iOS;
    
    [assembly: ExportRenderer(typeof(RedStepper), typeof(RedStepper_iOS))]
    namespace CustomStepper.iOS
    {
        public class RedStepper_iOS : StepperRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Stepper> e)
            {
                base.OnElementChanged(e);
    
                if (Control != null)
                    Control.TintColor = Color.Red.ToUIColor();
            }
        }
    }
