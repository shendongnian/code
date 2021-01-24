     public class YourCustomCanvas : Canvas
    {
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            var ep = e.Property;
            if (ep != null)
            {
                if(ep.Name == "Left")
                foreach (FrameworkElement child in Children)
                  SetLeft(child, GetLeft(child) / (double)e.OldValue * (double)e.NewValue);
                else if (ep.Name == "Top")
                    foreach (FrameworkElement child in Children)
                        SetTop(child, GetTop(child) / (double)e.OldValue * (double)e.NewValue);
            }
        }
    }
