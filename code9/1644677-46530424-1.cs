    private void Bol_Click(object sender, RoutedEventArgs e)
    {
        lbDivide.Text = "0";   /// in this line of code you're basically setting lbDivide.text to be 0 every time the button is clicked, so the else condition will never be met.
        btnBol.Opacity = 0.5;
        btnBol.IsEnabled = false;   /// you're basically disabling the button after the first click.
        lbPayment.Visibility = Visibility.Hidden;
        if (lbDivide.Text == "0")
        {
            btnQr.Opacity = 0.5;
            btnQr.IsEnabled = false;
            zero.Opacity = 0.2;
            zero.IsEnabled = false;
            double_zero.IsEnabled = false;
            double_zero.Opacity = 0.2;
        }
        else
        {
            btnQr.Opacity = 1;
            btnQr.IsEnabled = true;
            zero.Opacity = 1;
            double_zero.Opacity = 1;
            zero.IsEnabled = true;
            double_zero.IsEnabled = true;
        }
    }
