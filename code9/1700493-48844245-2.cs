        private string[] ExistingStates = {"state1", "state2"}; // Add items to the array when loading.
        private void saveMyFile()
        {
            StreamWriter outputFile;
            outputFile = File.AppendText("states.txt");
            foreach (var cbItem in statesComboBox.Items)
            {
                if (!ExistingStates.Contains(cbItem))
                    outputFile.WriteLine(cbItem);
            }
            outputFile.Close();
        }
