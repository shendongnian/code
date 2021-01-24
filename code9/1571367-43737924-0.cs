        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            System.Windows.Shapes.Ellipse ellipse = new Ellipse();
            ellipse.Fill = new SolidColorBrush(Colors.Red);
            ellipse.Margin = new Thickness(rnd.Next(0, (int)System.Windows.SystemParameters.PrimaryScreenWidth - 100), rnd.Next(1, (int)System.Windows.SystemParameters.PrimaryScreenHeight - 101), 0, 0);
            ellipse.Width = 100;
            ellipse.Height = 100;
            ellipse.Name = "ellipseTest";
            if (ellipseShown)
            {
                System.Windows.Shapes.Ellipse ellipse0 = MainGrid.FindName("ellipseTest") as System.Windows.Shapes.Ellipse;
                MainGrid.Children.Remove(ellipse0);
                MainGrid.UnregisterName("ellipseTest");
            }
            MainGrid.RegisterName("ellipseTest", ellipse);
            MainGrid.Children.Add(ellipse);
            ellipseShown = true;
        }
