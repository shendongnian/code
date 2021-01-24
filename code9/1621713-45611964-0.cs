    private void Label_Click(object sender, MouseButtonEventArgs e)
    {
        Label lb = (Label) sender;
        WrapPanel wp = (WrapPanel) lb.Parent;
        UIElement child = wp.Children.Cast<UIElement>().FirstOrDefault(a=>a.GetType() == typeof(CheckBox));
        if (child != null)
        {
            CheckBox cb = (CheckBox) child;
            cb.IsChecked = !cb.IsChecked;
        }
    }
