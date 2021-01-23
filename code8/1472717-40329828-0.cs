    public void makeButton(string link,int count)
    {
        string[] mySplit = link.Split(new char[] { '\\' });
        string[] name = mySplit.Last().Split(new char[] { '.' });
        string fName = name.First();
        string buttonName = fName;
        Button newBtn = new Button();
        newBtn.Content = buttonName;
        newBtn.Height = 30;
        newBtn.Width = 70;
        newBtn.Tag = link;
        newBtn.Margin =  new Thickness(-60, 90*count/1.5, 180,80);
        StackPanel sp = new StackPanel();
        sp.Children.Add(newBtn);
        mainGrid.Children.Add(sp);
        newBtn.Click += launchApp;
        //launchApp(link);
    }
    private void launchApp(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        if( btn == null )
            return;
          
        Process.Start(btn.Tag.ToString( ));
    }
