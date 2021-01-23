    private void Window_Loaded(object sender, RoutedEventArgs e)
                {
                    foreach (CheckBox check in FindVisualChildren<CheckBox>(Container))
                    {
                        if (check.IsChecked)
                           {
                               foreach (CheckBox check1 in FindVisualChildren<CheckBox>(Container))
                               {
                                   check1.IsChecked = true;
                               }
                               break;
                           }
                    }
                }
