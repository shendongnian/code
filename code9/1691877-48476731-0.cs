    private void commentButton_Click(object sender, RoutedEventArgs e)
    {
        if (String.IsNullOrWhiteSpace(commentTextbox.Text) == false)
        {
            menuText.Text += commentTextbox.Text;
            commentTextbox.Text = string.Empty;
        }
    }
