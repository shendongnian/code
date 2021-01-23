        Page p;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            p = (Page) Application.LoadComponent(new Uri("Views/EmployeeDetaiView.Xaml.xaml", UriKind.Relative));
            Frm.Content = p;
            // This will print 0
            int i = VisualTreeHelper.GetChildrenCount(p);
            System.Diagnostics.Debug.WriteLine("Children count = " + i);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Now it will correctly print 1, as 'p' is now part of VisualTree
            int i = VisualTreeHelper.GetChildrenCount(p);
            System.Diagnostics.Debug.WriteLine("Children count = " + i);
        }
