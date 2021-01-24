    private void Label_Click(object sender, MouseButtonEventArgs e)
    {
        Label lb = (Label) sender;
        WrapPanel wp = (WrapPanel) lb.Parent;
        CheckBox cb= wp.Children.OfType<CheckBox>().FirstOrDefault();
        if (cb!= null)
        {            
            cb.IsChecked = !cb.IsChecked;
        }
    }
