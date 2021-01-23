    private void checkAll_Checked(object sender, RoutedEventArgs e)
    {
        if (checkAll.IsChecked == true)
        {
            foreach (GridViewColumn gvc in gvMyGridView.Children)
            {
                foreach (CellTemplate ct in gvc)
                {
                    foreach (Checkbox cb in ct)
                    {
                        cb.IsChecked = true;
                    }
                }
            }
        }
    }
