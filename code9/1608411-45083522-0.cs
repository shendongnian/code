    AddNewCheckBox()
    {
         CheckBox NewCheckBox = new CheckBox ();
    
         NewCheckBox.Content = "CheckBox1";
         NewCheckBox.Height = 24;
         NewCheckBox.Click += NewCheckBox_Click;
         NewCheckBox.Margin = new Thickness(64, 41, 0, 0);
         NewCheckBox.Background = new SolidColorBrush(Color.Black);
         //or like this: NewCheckBox.Background = Brushes.Black;
    }
