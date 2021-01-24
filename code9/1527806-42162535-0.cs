    private void ComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            bool allowed = false;
            foreach (ComboBoxItem it in comboBox.Items)
            {
                if (it.Content.ToString() == comboBox.Text)
                {
                    allowed = true;
                    break;
                }
            }
            if (!allowed)
            {
                MessageBox.Show("MISS!");
            }
            else
            {
                MessageBox.Show("HIT!");
            }
        }
