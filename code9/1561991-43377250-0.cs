    private void Button2_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            subtractAmount = double.Parse(TextBox2.Text);
            newSalaryAmount = salaryAmount - subtractAmount;
            
            //Set the new current salary
            salaryAmount = newSalaryAmount
            label1.Content = newSalaryAmount.ToString();
        }
        catch (Exception)
        {
            MessageBox.Show("This was not a valid input.");
        }
    } 
