    private void Button_Click(object sender, RoutedEventArgs e)
    {
        for (int i =1; i < 50; i++)
        {
            string TB = "TB" + i;
            // credit to sTrenat
            TextBox TBN = this.Controls[TB];
           
            TBN.Text = "Textbox Changed";
        }
