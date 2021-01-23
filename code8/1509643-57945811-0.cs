        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var ue = e.Source as TextBox;
            Regex regex;
            if (ue.Text.Contains("."))
            {
                regex = new Regex("[^0-9]+");
            }
            else
            {
                regex = new Regex("[^0-9.]+");
            }
            e.Handled = regex.IsMatch(e.Text);
        }
