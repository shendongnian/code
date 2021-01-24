    private void SaveRoleBtn_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var parent = button.Parent as DockPanel;
        if(parent != null)
        {
            var textBox = parent.Children.OfType<TextBox>().FirstOrDefault();
            if (textBox != null)
                MessageBox.Show(textBox.Text);
            else
                MessageBox.Show("Is null");
        }
    }
