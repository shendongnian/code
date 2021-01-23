        private void AreaOfParallelogramCalcBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDouble(AreaOfParallelogramHeightTxtBox.Text) > 25000000)
            {
                MessageBox.Show(string.Format("Height input out of range.  Height must be less than 25,000,000\n{0:n0} is a pretty big number.  Please try again.", Convert.ToDouble(AreaOfParallelogramHeightTxtBox.Text)), "*WARNING*", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (Convert.ToDouble(AreaOfParallelogramWidthTxtBox.Text) > 25000000)
            {
                MessageBox.Show(string.Format("Width input out of range.  Width must be less than 25,000,000\n{0:n0} is a pretty big number.  Please try again.", Convert.ToDouble(AreaOfParallelogramWidthTxtBox.Text)), "*WARNING*", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                AreaOfParallelogramResultTxtBox.Text =
                CalculateAreaOfParallelogram.Calculate(Convert.ToDouble(AreaOfParallelogramHeightTxtBox.Text),
                Convert.ToDouble(AreaOfParallelogramWidthTxtBox.Text)).ToString();
            }
        }
