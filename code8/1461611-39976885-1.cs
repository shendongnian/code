    visual=YourGridName;
    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
    {
        Visual childVisual = (Visual) VisualTreeHelper.GetChild(visual, i);
        if (childVisual is TextBox)
        {
              TextBox tempTextBox = childVisual as TextBox;
              if(tempTextBox.IsVisible)
              {
              tempTextBox.Focus();
              }
        }
    }`
