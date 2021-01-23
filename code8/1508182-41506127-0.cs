    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
            {
                int value = int.Parse(YourTextBox.Text);
                if (value<10)
                {
                    YourTextBox.Text = "0" + value;
                }
            }
