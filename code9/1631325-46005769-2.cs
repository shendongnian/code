        private void Window_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var element = Mouse.DirectlyOver as FrameworkElement;
            StatusBarLabel.Content = GetTooltip(element);  
        }
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
