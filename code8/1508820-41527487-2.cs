        private void AreaOfParallelogramCalcBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDouble(AreaOfParallelogramHeightTxtBox.Text) > 25000000)
            {
                MessageBox.Show($"Height input out of range.  Height must be less than 25,000,000\n{Convert.ToDouble(AreaOfParallelogramHeightTxtBox.Text):n0} is a pretty big number.  Please try again.", "*WARNING*", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (Convert.ToDouble(AreaOfParallelogramWidthTxtBox.Text) > 25000000)
            {
                MessageBox.Show($"Width input out of range.  Width must be less than 25,000,000\n{Convert.ToDouble(AreaOfParallelogramWidthTxtBox.Text):n0} is a pretty big number.  Please try again.", "*WARNING*", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                AreaOfParallelogramResultTxtBox.Text =
                CalculateAreaOfParallelogram.Calculate(Convert.ToDouble(AreaOfParallelogramHeightTxtBox.Text),
                Convert.ToDouble(AreaOfParallelogramWidthTxtBox.Text)).ToString(CultureInfo.InvariantCulture);
            }
        }
