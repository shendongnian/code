     private void image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            while (e.ButtonState == MouseButtonState.Pressed)
            {
              this.DragMove();
              Debug.WriteLine("Dragged!");
            }
            var image = sender as Image;
            object parent = FindParent(image);
            while (parent != null && parent.GetType() != typeof(Button))
            {
                parent = FindParent((FrameworkElement)parent);
            }
            var bt = parent as Button;
            if(bt != null)
            bt.ClickMode = ClickMode.Press;
        }
        private void DialButton_OnClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Clicked!");
        }
        DependencyObject FindParent(FrameworkElement ui)
        {
            return ui.TemplatedParent;
        }
    }
