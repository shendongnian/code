    private void TextBox1_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      if (TextBox1.Visibility == Visibility.Visible)
      {
         FocusManager.SetFocusedElement(Grid1, TextBox1);
      }
    }
