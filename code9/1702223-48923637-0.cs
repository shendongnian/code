        base.OnElementChanged(e);
        if (Control != null && Element != null)
        {
            Control.Background = new SolidColorBrush(Colors.Transparent);
            Control.PlaceholderText = "Select";
            Control.BorderBrush = new SolidColorBrush(Colors.Transparent);
            Control.VerticalContentAlignment = VerticalAlignment.Center;
            Control.HorizontalContentAlignment = HorizontalAlignment.Left;
            Control.Foreground = new SolidColorBrush(Colors.Black);         
            var element = Element as BurndyRegPicker; 
            element.Title = string.Empty;?                
            element.Margin = new Xamarin.Forms.Thickness(-10, -6, -28, 4);
            }
        }
    }
