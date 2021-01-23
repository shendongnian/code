        private void AreaOfParallelogramCalcBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDouble(AreaOfParallelogramHeightTxtBox.Text) > 25000000)
            {
                MessageBox.Show(string.Format("Seriously? {0:n0} is a pretty big number.  Please try again.", Convert.ToDouble(AreaOfParallelogramHeightTxtBox.Text)));
            }
            else if (Convert.ToDouble(AreaOfParallelogramWidthTxtBox.Text) > 25000000)
            {
                MessageBox.Show(string.Format("Seriously? {0:n0} is a pretty big number.  Please try again.", Convert.ToDouble(AreaOfParallelogramWidthTxtBox.Text)));
            }
            else
            {
                AreaOfParallelogramResultTxtBox.Text =
                CalculateAreaOfParallelogram.Calculate(Convert.ToDouble(AreaOfParallelogramHeightTxtBox.Text),
                Convert.ToDouble(AreaOfParallelogramWidthTxtBox.Text)).ToString();
            }
        }
