    private void GenerateNameButton_Click(object sender, RoutedEventArgs e)
        {
            int seedValue;
    
            try
            {
                seedValue = int.Parse(SeedNumberTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Not a valid seed number. Try again.", "Invalid Seed Number", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
    
            namesGenerator.SetSeedValue(seedValue);
            AddNewName(namesGenerator.GenerateName());
        }
