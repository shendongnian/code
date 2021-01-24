    public class MyMenuItem : MenuItem
    {
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == IconProperty)
            {
                if (e.OldValue != null)
                    RemoveLogicalChild(e.OldValue);
                if (e.NewValue != null)
                    AddLogicalChild(e.NewValue);
            }
        }
    }
