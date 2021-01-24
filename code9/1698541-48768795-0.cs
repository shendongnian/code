    public class ButtonRenderer : Xamarin.Forms.Platform.Android.ButtonRenderer
    {
        // Your Button class
        Button button;
        float radius = 0;
        //--------------------------------------------------------------------------------//
        public ButtonRenderer() : base(MainActivity.Activity) { }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            button = Element as Button;
            if (e.OldElement == null)
            {
                if (IsPostLollipopAndroid) Control.Elevation = 2;
                radius = (float)button.CornerRadius;
                if (button.Padding != null)
                {
                    Control.SetPadding(ToPx((int)button.Padding.Left), ToPx((int)button.Padding.Top), ToPx((int)button.Padding.Right), ToPx((int)button.Padding.Bottom));
                }
                SetColors();
                Control.SetMinHeight(0);
                Control.SetMinimumHeight(0);
                Control.SetMinWidth(0);
                Control.SetMinimumWidth(0);
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            switch (e.PropertyName)
            {
                case nameof(VisualElement.BackgroundColor):
                case nameof(Button.PressedColor):
                    {
                        SetColors();
                        break;
                    }
                case nameof(Button.Padding):
                    {
                        if (button.Padding != null)
                        {
                            Control.SetPadding((int)button.Padding.Left, (int)button.Padding.Top, (int)button.Padding.Right, (int)button.Padding.Bottom);
                        }
                        break;
                    }
            }
        }
        public override bool DispatchTouchEvent(MotionEvent e)
        {
            if (!Element.InputTransparent) return base.DispatchTouchEvent(e);
            else return true;
        }
        void SetColors()
        {
            radius = (float)button.CornerRadius;
            StateListDrawable list = new StateListDrawable();
            if (IsPreLollipopAndroid)
            {
                GradientDrawable pressedDrawable;
                if (Element.BackgroundColor != Color.Transparent)
                {
                    Android.Graphics.Color pressedColor = ChangeColorBrightness(Element.BackgroundColor, (button.PressedColor == ButtonPressedColor.Dark) ? 1f - (float).15 : 1f + (float).15).ToAndroid();
                    pressedDrawable = new GradientDrawable(GradientDrawable.Orientation.LeftRight, new int[] { pressedColor, pressedColor });
                    pressedDrawable.SetCornerRadius(ToPxFloat(radius));
                }
                else
                {
                    Android.Graphics.Color pressedColor = (button.PressedColor == ButtonPressedColor.Dark) ? Color.Black.MultiplyAlpha(.15).ToAndroid() : Color.White.MultiplyAlpha(.15).ToAndroid();
                    pressedDrawable = new GradientDrawable(GradientDrawable.Orientation.LeftRight, new int[] { pressedColor, pressedColor });
                    pressedDrawable.SetCornerRadius(ToPxFloat(radius));
                }
                list.AddState(new int[] { Android.Resource.Attribute.StatePressed }, pressedDrawable);
                //--------------------------------------------------------------------------------//
                Android.Graphics.Color color = Element.BackgroundColor.ToAndroid();
                var normalDrawable = new GradientDrawable(GradientDrawable.Orientation.LeftRight, new int[] { color, color });
                normalDrawable.SetCornerRadius(ToPxFloat(radius));
                list.AddState(new int[] { -Android.Resource.Attribute.StatePressed }, normalDrawable);
                Control.Background = list;
            }
            else
            {
                GradientDrawable normalDrawable = new GradientDrawable();
                normalDrawable.SetCornerRadius(ToPxFloat(radius));
                normalDrawable.SetColor(Element.BackgroundColor.ToAndroid());
                float[] outerRadii = Enumerable.Repeat(ToPxFloat(radius), 8).ToArray();
                RoundRectShape r = new RoundRectShape(outerRadii, null, null);
                ShapeDrawable shapeDrawable = new ShapeDrawable(r);
                shapeDrawable.Paint.Color = Color.White.ToAndroid();
                var pressedColor = (button.PressedColor == ButtonPressedColor.Dark) ? Color.Black.MultiplyAlpha(.15).ToAndroid() : Color.White.MultiplyAlpha(.15).ToAndroid();
                var ripple = new RippleDrawable(ColorStateList.ValueOf(pressedColor), normalDrawable, shapeDrawable);
                Control.Background = ripple;
            }
        }
        public static int ToPx(double dp)
        {
            return (int)Android.Util.TypedValue.ApplyDimension(Android.Util.ComplexUnitType.Dip, (float)dp, Droid.MainActivity.Activity.Resources.DisplayMetrics);
        }
        
        public static float ToPxFloat(double dp)
        {
            return Android.Util.TypedValue.ApplyDimension(Android.Util.ComplexUnitType.Dip, (float)dp, Droid.MainActivity.Activity.Resources.DisplayMetrics);
        }
        public static bool IsPreLollipopAndroid => Android.OS.Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Lollipop;
        public static bool IsPostLollipopAndroid => Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop;
        
        public static Color ChangeColorBrightness(Color color, float factor)
        {
            return Color.FromRgba(color.R * factor, color.G * factor, color.B * factor, color.A);
        }
    }
