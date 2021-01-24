        private void Window_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var element = Mouse.DirectlyOver as FrameworkElement;
            HoverToolTip = GetTooltip(element);  
        }
        #region HoverToolTip Property
        public object HoverToolTip
        {
            get { return (object)GetValue(HoverToolTipProperty); }
            set { SetValue(HoverToolTipProperty, value); }
        }
        public static readonly DependencyProperty HoverToolTipProperty =
            DependencyProperty.Register(nameof(HoverToolTip), typeof(object), typeof(MainWindow),
                new PropertyMetadata(null));
        #endregion HoverToolTip Property
        protected static Object GetTooltip(FrameworkElement obj)
        {
            if (obj == null)
            {
                return null;
            }
            else if (obj.ToolTip != null)
            {
                return obj.ToolTip;
            }
            else
            {
                return GetTooltip(VisualTreeHelper.GetParent(obj) as FrameworkElement);
            }
        }
