    private void Button_Click(object sender, RoutedEventArgs e)
    {
        for (int i =1; i < 50; i++)
        {
            string TB = "TB" + i;
            TextBox TBN = this.Controls[TB];
            TBN.Name = TB;
            TBN.Text = "Textbox Changed";
        }
