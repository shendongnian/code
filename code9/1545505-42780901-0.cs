    class CTRLEnterTextBox : TextBox
    {
        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            if (Window.Current.CoreWindow.GetKeyState(VirtualKey.Control).HasFlag(CoreVirtualKeyStates.Down) && e.Key == VirtualKey.Enter)
            {
                e.Handled = true;
            }
            else
            {
                base.OnKeyDown(e);
            }
        }
    }
