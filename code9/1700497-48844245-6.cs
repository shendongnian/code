        private void saveMyFile()
        {
            StreamWriter outputFile;
            outputFile = File.CreateText("states.txt");
            foreach (var cbItem in statesComboBox.Items)
            {
                outputFile.WriteLine(cbItem);
            }
            outputFile.Close();
        }
