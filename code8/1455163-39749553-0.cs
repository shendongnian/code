            private void View_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            updateTextbox();
        }
        private void View_OnMouseLeave(object sender, MouseEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                Mouse.AddPreviewMouseDownHandler(parentWindow, ParentWindow_OnMouseDown);
            }
        }
        private void View_OnMouseEnter(object sender, MouseEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                Mouse.RemovePreviewMouseDownHandler(parentWindow, ParentWindow_OnMouseDown);
            }
        }
        private void ParentWindow_OnMouseDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                Mouse.RemovePreviewMouseDownHandler(parentWindow, ParentWindow_OnMouseDown);
            }
            updateTextbox();
        }
        private void updateTextbox()
        {
            Keyboard.Focus(this);
        }
        private void Text_OnGotFocus(object sender, RoutedEventArgs e)
        {
            MouseDown += View_OnMouseDown;
            MouseLeave += View_OnMouseLeave;
            MouseEnter += View_OnMouseEnter;
        }
        private void Text_OnLostFocus(object sender, RoutedEventArgs e)
        {
            BindingOperations.GetBindingExpression(text, TextBox.TextProperty).UpdateSource();
            MouseDown -= View_OnMouseDown;
            MouseLeave -= View_OnMouseLeave;
            MouseEnter -= View_OnMouseEnter;
        }
