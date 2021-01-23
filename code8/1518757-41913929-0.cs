          private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                // the original source is what was clicked.  For example 
                // a button.
                DependencyObject dep = (DependencyObject)e.OriginalSource;
                // iteratively traverse the visual tree upwards looking for
                // the clicked row.
                while ((dep != null) && !(dep is DataGridRow))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }
                // if we found the clicked row
                if (dep != null && dep is DataGridRow)
                {
                    DataGridRow row = (DataGridRow)dep;
                  
                    
                    // change the details visibility
                    if (row.DetailsVisibility == Visibility.Collapsed)
                    {
                        row.DetailsVisibility = Visibility.Visible;
                        KalaClass krow = (KalaClass)row.Item;
                        if (krow != null)
                        {
                            IQueryable<product> q = from p in entity.Products
                                                    where p.productID == krow.KalaID
                                                    select p;
                            curentProduct = q.First();
                        }
                    }
                    else
                    {
                        row.DetailsVisibility = Visibility.Collapsed;
                    }
                }
                //dgRowProFill(curentProduct);
            }
            catch (System.Exception)
            {
            }
        }
