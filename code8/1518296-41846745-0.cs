    Button btn = new Button();
    btn.Tag = item; // .Value maybe?
    // ...
    void btn_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        Customer cust = (Customer)button.Tag;
    }
