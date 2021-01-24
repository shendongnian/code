    public class CustomFrameRenderer : Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer
    {
        private Color backgroundColor;
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            backgroundColor = Element.BackgroundColor;
            Control.Touch += Control_Touch;
        }
        private void Control_Touch(object sender, TouchEventArgs e)
        {
            switch (e.Event.Action)
            {
                case MotionEventActions.Down:
                    Element.BackgroundColor = Color.Green;
                    break;
                case MotionEventActions.Up:
                    Element.BackgroundColor = backgroundColor;
                    break;
            }
        }
    }
