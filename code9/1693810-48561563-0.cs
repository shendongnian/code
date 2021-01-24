    for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                {
                    if (vis is DataGridRow)
                    {
                        var row = (DataGridRow)vis;
                        row.DetailsVisibility = row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                        row.UpdateLayout();
                        var height = row.RenderSize.Height; 
                        var exp = sender as Expander;
                        ((StackPanel)VisualTreeHelper.GetParent(exp)).Height = height;
                        break;
                    }
                }
