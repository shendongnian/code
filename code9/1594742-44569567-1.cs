        private void txt1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).MaxLength == ((TextBox)sender).Text.Length)
            {
                // move focus
                var ue = e.OriginalSource as FrameworkElement;
                e.Handled = true;
                ue.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }
