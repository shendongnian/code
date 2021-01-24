    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(this.spSideNav); i++) // in sidenav stack panel
            {
                    DependencyObject current = VisualTreeHelper.GetChild(this.spSideNav, this.currentlyActive + 1);
                    if (current.GetType().Equals(typeof(Button)))
                    {
                        Button btn = (Button)current;
                        btn.Background = Brushes.DarkBlue;
                        for (int j = 0; j < VisualTreeHelper.GetChildrenCount(current); j++) // in button
                        {
                            current = VisualTreeHelper.GetChild(current, j);
                            if (current.GetType().Equals(typeof(Border)))
                            {
                                for (int k = 0; k < VisualTreeHelper.GetChildrenCount(current); k++) // in border
                                {
                                    current = VisualTreeHelper.GetChild(current, k);
                                    Border b = (Border)current;
                                    b.Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#00BAC0")); 
                                    ..........
                                    more code
                                 }
                             }
                          }
                      }
               }
