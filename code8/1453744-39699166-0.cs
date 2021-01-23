        private void BtnDisplay1000_Click(object sender, RoutedEventArgs e)
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    stringBuilder.Append(i);
                    stringBuilder.Append(", ");
                }
            }
            TxtDisplay1000.Text = (stringBuilder.ToString());
        }
