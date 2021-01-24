        private int ExistingStates = 3; // You can later change this number when loading the items
        private void saveMyFile()
        {
            StreamWriter outputFile;
            outputFile = File.CreateText("states.txt");
            foreach (var cbItem in statesComboBox.Items.Cast<string>().Skip(ExistingStates))
            {
                outputFile.WriteLine(cbItem);
            }
            outputFile.Close();
        }
