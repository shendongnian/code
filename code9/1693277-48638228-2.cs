    protected override void OnElementChanged(ElementChangedEventArgs<Stepper> e)
    {
        base.OnElementChanged(e);
        MyStepper s = Element as MyStepper;
        if (Control != null)
        {
            var button = Control.GetChildAt(0) as Android.Widget.Button;
            button.SetTextColor(s.MyColor.ToAndroid());
            button.SetBackground(ResourcesCompat.GetDrawable(Resources, Resource.Drawable.button_selector, null));
            button.Background.SetColorFilter(s.MyColor.ToAndroid(), PorterDuff.Mode.Multiply);
            var button2 = Control.GetChildAt(1) as Android.Widget.Button;
            button2.SetTextColor(s.MyColor.ToAndroid());
            button2.SetBackground(ResourcesCompat.GetDrawable(Resources, Resource.Drawable.button_selector, null));
            button2.Background.SetColorFilter(s.MyColor.ToAndroid(), PorterDuff.Mode.Multiply);
        }
    }
