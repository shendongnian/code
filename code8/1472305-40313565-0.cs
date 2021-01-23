    // ListaPendencia is populated from database MnMe is a column from it
    foreach (string item in ListaPendencia.Select(p => p.MnMe).Distinct())
    {
        checkBox = new System.Windows.Controls.CheckBox();
        checkBox.Content = item;
       
        checkBox.IsEnabled = false;
        checkBox.Background = new SolidColorBrush(Color.FromRgb(102, 153, 255));
        
        cmbMnMe.Items.Add(checkBox);    
    }
    
