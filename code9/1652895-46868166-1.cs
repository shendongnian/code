    public void button_Click(object sender, RoutedEventArgs e)
    {
        checkBool cb = new checkBool();
        if (checkBox1.IsChecked == true)
        {
            cb.checkTrue(textbox);
        }
        else
        {
            cb.checkFalse(textbox);
        }
    }
Keep in mind that by doing this you are introducing a dependency to your class checkBool (It depends to TextBox now).
