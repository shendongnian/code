        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(View.IsEnabled))
            {
                   //update background here 
                   if(Element IsEnabled) 
                       Control.BackgroundColor=... ;
            }
        }
