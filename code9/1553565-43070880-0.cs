        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(e.PropertyName == "IsEnabled")
            {
                if(Element.IsEnabled)
                    Control.SetTextColor(Color.ParseColor("#858585"));
                else
                    Control.SetTextColor(Element.TextColor.ToAndroid());
            }
        }
