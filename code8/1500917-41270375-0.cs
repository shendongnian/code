    public class OverlayDisableControl : UserControl
    {
        private Grid overlay = new Grid
        {
            Name = "Overlay",
            Visibility = Visibility.Collapsed
        };
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            ...
            //Grid overlay = new Grid
            //{
            //    Name = "Overlay",
            //    Visibility = Visibility.Collapsed
            //};
            ...
        }
        ...
        private static void SetOverlayVisibleStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as OverlayDisableControl).SetOverlayVisible((bool)e.NewValue);
        }
        private void SetOverlayVisible(bool visible)
        {
            if (visible)
            {
                DoubleAnimation anim = new DoubleAnimation
                {
                    ...
                };
                overlay.Visibility = Visibility.Visible;
                overlay.BeginAnimation(OpacityProperty, anim);
            }
            else
            {
                DoubleAnimation anim = new DoubleAnimation
                {
                    ...
                };
                anim.Completed += (s1, e1) => {
                    overlay.Visibility = Visibility.Collapsed;
                };
                overlay.BeginAnimation(OpacityProperty, anim);
            }
        }
    }
