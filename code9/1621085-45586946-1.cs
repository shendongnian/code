    private void VisibilityChanged(DependencyObject sender, DependencyProperty dp)
    {
      if (((UIElement)sender).Visibility == Visibility.Visible)
      {
        TextBox1.Focus(FocusState.Keyboard);
      }
    }
