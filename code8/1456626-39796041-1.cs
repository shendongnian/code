        private void randomButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.numberComboBox.SelectedIndex != -1 && Convert.ToInt16(this.numberComboBox.SelectedItem) <= personListBox.Items.Count)
            {               
                int number = Convert.ToInt16(this.numberComboBox.SelectedItem);
                
                for (int i = 0; i < number; i++)
                {
                    int randomValue = random.Next(personListBox.Items.Count);                    
                    var person =  personListBox.Items[randomValue];
                    personListBox.Items.RemoveAt(randomValue);
                    personListBox2.Items.Add(person);
                }
            } 
            else
            {
                MessageBox.Show("Please select a number before trying to random.");
            }
       }
