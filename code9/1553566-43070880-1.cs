        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(e.PropertyName == "IsEnabled")
            {
                if(Element.IsEnabled)
                {
                    Control.SetTextColor(Color.ParseColor("#858585"));
                    Control.SetBackgroundResource(Resource.Drawable.YourEnabledResource);
                }
                else
                {
                    Control.SetTextColor(Element.TextColor.ToAndroid());
                    Control.SetBackgroundResource(Resource.Drawable.YourDisabledResource);
                }
            }
        }
