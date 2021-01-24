        public bool NeedToDrawRect
        {
            get { return (bool)GetValue(NeedToDrawRectProperty); }
            set
            {
                SetValue(NeedToDrawRectProperty, value);
            }
        }
        
        public static readonly DependencyProperty NeedToDrawRectProperty =
            DependencyProperty.Register("NeedToDrawRect",
                typeof(bool),
                typeof(PanZoomImage),
                new PropertyMetadata(false, OnNeedToDrawRectChanged ));
        private static void OnNeedToDrawRectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as PanZoomImage;
            if (control!=null && (bool)e.NewValue == false && (bool)e.OldValue == true)
            {
                control.NeedToDrawRect = true; // user won't be able to set it to false again.
            }
        }
