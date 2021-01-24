    private void Label_Click(object sender, MouseButtonEventArgs e)
    {
       var checkbox = ((sender as Label).Parent as WrapPanel).Children.OfType<CheckBox>().FirstOrDefault();
       checkbox.IsChecked = !checkbox.IsChecked;
    }
