      private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
      {
          if (depObj != null)
          {
              for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
              {
                  DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                  if (child != null && child is T)
                  {
                      yield return (T)child;
                  }
                  foreach (T childOfChild in FindVisualChildren<T>(child))
                  {
                      yield return childOfChild;
                  }
              }
          }
      }
      private void getbutton1_Click(object sender, RoutedEventArgs e)
      {
          Button _button1 = null;
          IEnumerable<Button> buttons = FindVisualChildren<Button>(mycontrol);
          foreach (var _button in buttons)
          {
              if (_button.Name == "Button1")
              {
                 _button1 = _button;
              }
          }
          System.Diagnostics.Debug.WriteLine(_button1.Content);
      }
