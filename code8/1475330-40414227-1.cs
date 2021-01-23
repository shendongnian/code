    [assembly: ExportRenderer(typeof(App2.FancyButton), typeof(FancyButtonAndroid))]
    namespace App2.Droid {
        public class FancyButtonAndroid : ButtonRenderer {
            private Color _pressedDownColor;
            protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e) {
                base.OnElementChanged(e);
                Android.Widget.Button thisButton = Control as Android.Widget.Button;
                FancyButton formsButton = (FancyButton)Element;
                _pressedDownColor = formsButton.PressedDownColor;
                thisButton.Touch += (object sender, Android.Views.View.TouchEventArgs e2) => {
                    if (e2.Event.Action == MotionEventActions.Down) {
                        thisButton.SetBackgroundColor(_pressedDownColor.ToAndroid());
                    } else if (e2.Event.Action == MotionEventActions.Up) {
                        thisButton.SetBackgroundColor(Xamarin.Forms.Color.Default.ToAndroid());
                    }
                };
            }
            /// <summary>
            /// Raises the element property changed event.
            /// </summary>
            /// <param name="sender">Sender</param>
            /// <param name="e">The event arguments</param>
            protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
                base.OnElementPropertyChanged(sender, e);
                FancyButton formsButton = Element as FancyButton;
                if(formsButton != null && e.PropertyName == FancyButton.PlaceholderProperty.PropertyName) {
                    _pressedDownColor = formsButton.PressedDownColor;
                }
            }
        }
    }
