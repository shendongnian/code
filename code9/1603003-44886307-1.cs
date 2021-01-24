    private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                ComboBox2.SelectedIndex = -1;
                string cb1 = ComboBox1.SelectedValue as string;
                cars2.Clear();
                cars2.AddRange(cars);
                cars2.Remove(cb1);
                ComboBox2.ItemsSource = null;
                ComboBox2.ItemsSource = cars2;
            }
