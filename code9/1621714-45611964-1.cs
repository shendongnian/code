    private void Label_Click(object sender, MouseButtonEventArgs e)
    {
        Label lb = (Label) sender;
        WrapPanel wp = (WrapPanel) lb.Parent;
        UIElement child = wp.Children.OfType<CheckBox>().FirstOrDefault();
        if (child != null)
        {
            CheckBox cb = (CheckBox) child;
            cb.IsChecked = !cb.IsChecked;
        }
    }
