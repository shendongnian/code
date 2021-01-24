        private void toolBar1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                Point p = e.GetPosition(toolBar1);
                IInputElement ie = toolBar1.InputHitTest(p);
                Thumb t = GetParent<Thumb>(ie as DependencyObject);
                if(t != null)
                {
                    // we have clicked on the grip...
                }
            }
        }
        private T GetParent<T>(DependencyObject d) where T : class
        {
            while (d != null && !(d is T))
            {
                d = VisualTreeHelper.GetParent(d);
            }
            return d as T;
        }
