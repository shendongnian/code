    private void button1_Click(object sender, RoutedEventArgs e)
    {
       if (listBox.SelectedIndex != -1)
          listBox.Items.RemoveAt(listBox.SelectedIndex);
       else
          System.Windows.MessageBox.Show("You have not selected an item");
    }
