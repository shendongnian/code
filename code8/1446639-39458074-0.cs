    private void inputTextBox_TextChanged(object sender, EventArgs e)
            {
                var inputTextBox = sender as TextBox;
                var sourceValue = inputTextBox.Text;
                double doubleValue;
                if (double.TryParse(sourceValue, out doubleValue))
                {
                    if (doubleValue > 1000)
                    {
                        MessageBox.Show("Cannot be greater than 1000");
                    }
                }
            }
