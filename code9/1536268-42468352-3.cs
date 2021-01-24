    private void button_Click(object sender, RoutedEventArgs e)
    {
        ImageBrush b1 = new ImageBrush();
        b1.ImageSource = new BitmapImage(new Uri(@"---\lightsonNOlaptop.jpg"));
        MainWindow mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        if(mw != null)
            mw.PIC.Backgound = b1;
    }
