    
    using Android.Widget;
    using Android.Graphics;
    
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    
    using CustomStepper.Droid;
    
    [assembly: ResolutionGroupName("CustomStepper")]
    [assembly: ExportEffect(typeof(StepperColorEffect), nameof(StepperColorEffect))]
    namespace CustomStepper.Droid
    {
        public class StepperColorEffect : PlatformEffect
        {
            protected override void OnAttached()
            {
                if (Element is Stepper element && Control is LinearLayout control)
                {
                    control.GetChildAt(0).Background.SetColorFilter(CustomStepper.StepperColorEffect.GetColor(element).ToAndroid(), PorterDuff.Mode.Multiply);
                    control.GetChildAt(1).Background.SetColorFilter(CustomStepper.StepperColorEffect.GetColor(element).ToAndroid(), PorterDuff.Mode.Multiply);
                }
            }
    
            protected override void OnDetached()
            {
                if (Element is Stepper element && Control is LinearLayout control)
                {
                    control.GetChildAt(0).Background.SetColorFilter(Xamarin.Forms.Color.Gray.ToAndroid(), PorterDuff.Mode.Multiply);
                    control.GetChildAt(1).Background.SetColorFilter(Xamarin.Forms.Color.Gray.ToAndroid(), PorterDuff.Mode.Multiply);
                }
            }
        }
    }
