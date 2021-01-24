    public class CustomImage : Image
    {
        public static readonly BindableProperty IsImageShowingProperty = BindableProperty.Create("IsImageShowing", typeof(bool), typeof(CustomImage), false, BindingMode.Default, propertyChanged: OnImageShowingChanged);
        private static void OnImageShowingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if(newValue == null) return;
            var img = (CustomImage)bindable;
            var b = (bool)newValue;
            if(b)
            {
                img.ShowImage();
            }
            else
            {
                img.HideImage();
            }
        }
        public bool IsImageShowing
        {
            get {  return (bool)GetValue(IsImageShowingProperty); }
            set { SetValue(IsImageShowingProperty, value); }
        }
        public void ShowImage()
        {
            this.FadeTo(1, 1000, Easing.SinIn);
        }
        public void HideImage()
        {
            this.FadeTo(0, easing: Easing.SinIn);
        }
    }
