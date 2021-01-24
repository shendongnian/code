    using Android.Content;
    using Android.Graphics;
    
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    
    using CustomStepper;
    using CustomStepper.Droid;
    
    [assembly: ExportRenderer(typeof(RedStepper), typeof(RedStepper_Android))]
    namespace CustomStepper.Droid
    {
        public class RedStepper_Android : StepperRenderer
        {
            public RedStepper_Android(Context context) : base(context)
            {
            }
    
            protected override void OnElementChanged(ElementChangedEventArgs<Stepper> e)
            {
                base.OnElementChanged(e);
    
                if (Control != null)
                {
                    Control.GetChildAt(0).Background.SetColorFilter(Xamarin.Forms.Color.Red.ToAndroid(), PorterDuff.Mode.Multiply);
                    Control.GetChildAt(1).Background.SetColorFilter(Xamarin.Forms.Color.Red.ToAndroid(), PorterDuff.Mode.Multiply);
                }
            }
        }
    }
