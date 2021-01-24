    using UIKit;
    
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    
    using CustomStepper.iOS;
    
    [assembly: ResolutionGroupName("CustomStepper")]
    [assembly: ExportEffect(typeof(StepperColorEffect), nameof(StepperColorEffect))]
    namespace CustomStepper.iOS
    {
        public class StepperColorEffect : PlatformEffect
        {
            protected override void OnAttached()
            {
                if (Element is Stepper element && Control is UIStepper control)
                    control.TintColor = CustomStepper.StepperColorEffect.GetColor(element).ToUIColor();
            }
    
            protected override void OnDetached()
            {
                if (Element is Stepper element && Control is UIStepper control)
                    control.TintColor = UIColor.Blue;
            }
        }
    }
