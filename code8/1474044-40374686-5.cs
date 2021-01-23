     protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);
                if (e.PropertyName == Xamarin.Forms.ListView.HeightRequestProperty.PropertyName)
                {
                    Control.LayoutParameters.Height =(int)(sender as Xamarin.Forms.ListView).HeightRequest;
                    Control.RequestLayout();
                    
                }
            }  
