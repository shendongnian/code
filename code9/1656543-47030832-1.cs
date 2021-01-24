    [assembly: ExportRenderer(typeof(MyFrame), typeof(MyFrameRenderer))]
    namespace Android.Renderers
    {
      public class MyFrameRenderer : VisualElementRenderer<Frame>
      {
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var drawable = new GradientDrawable();
                ViewGroup.SetBackground(drawable);
                UpdateBackgroundColor(drawable);
                UpdateCornerRadius(drawable);
                UpdateOutlineColor(drawable);
                UpdateShadow();
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var drawable = ViewGroup?.Background as GradientDrawable;
            if (drawable != null)
            {
                if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
                {
                    UpdateBackgroundColor(drawable);
                } 
                else if (e.PropertyName == Frame.CornerRadiusProperty.PropertyName)
                {
                    UpdateCornerRadius(drawable);
                }
                else if (e.PropertyName == Frame.OutlineColorProperty.PropertyName)
                {
                    UpdateOutlineColor(drawable);
                }
                else if (e.PropertyName == Frame.HasShadowProperty.PropertyName)
                {
                    UpdateShadow();
                }
            }
        }
        protected override void UpdateBackgroundColor()
        {
            // This method doesn't work well in Xamarin.Forms -Version 2.3.4.247
        }
        private void UpdateCornerRadius(GradientDrawable drawable)
        {
            drawable.SetCornerRadius(Element.CornerRadius);
        }
        private void UpdateOutlineColor(GradientDrawable drawable)
        {
            drawable.SetStroke(1, Element.OutlineColor.ToAndroid());
        }
        private void UpdateBackgroundColor(GradientDrawable drawable)
        {
            drawable.SetColor(Element.BackgroundColor.ToAndroid());
        }
        private void UpdateShadow()
        {
            if (Element.HasShadow)
            {
                Elevation = (float)Context.FromPixels(10);
            }
            else
            {
                Elevation = 0;
            }
        }
      }
    }
