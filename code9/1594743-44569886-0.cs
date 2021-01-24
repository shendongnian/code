    private void txt1_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // Auto-tab when maxlength is reached
            if (((TextBox)sender).MaxLength == ((TextBox)sender).Text.Length)
            {
                if(e.Key != Key.Delete && e.Key != Key.Clear && e.Key != Key.Back && ((TextBox)sender).SelectionLength == 0)
                {
                    // move focus
                    var ue = e.OriginalSource as FrameworkElement;
                    e.Handled = true;
                    ue.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                } 
                
            }
        }
