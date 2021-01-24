        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Uri")
                Control.LoadRequest(new NSUrlRequest(new NSUrl(Element.Uri)));
        }
