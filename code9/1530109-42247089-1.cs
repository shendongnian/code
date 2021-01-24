    public class MScrollBar : System.Windows.Controls.Primitives.ScrollBar
    {
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.Property == System.Windows.Controls.Primitives.ScrollBar.MaximumProperty)
            {
                // do stuff
            }
            base.OnPropertyChanged(e);
        }
    }
