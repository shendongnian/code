    public void BT_Root_Click(object sender, RoutedEventArgs e) 
    {
        double number1 = 0;
        double number2 = 0;
        double result = 0;
        if (RadioBT_Root2.IsChecked)
        {
            number1 = double.Parse(TXB_1.Text);
            result = Math.Sqrt(number1);
        }
        else if (RadioBT_Root3.IsChecked)
        {
            number1 = double.Parse(TXB_1.Text);
            number2 = (1 / 3.0);
            result = Math.Pow(number1, number2);
        }
        else if (RadioBT_Root4.IsChecked)
        {
            number1 = double.Parse(TXB_1.Text);
            number2 = (1 / 4.0);
            result = Math.Pow(number1, number2);
        }
        MessageBox.Show("RESULT: " + result.ToString());
    }
