        using (StreamReader streamReader = new StreamReader(logpath))
        {
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.LastIndexOf("Application engine version 2.0.2016 was initiated") > 0)
                {
                    richTextBox1.SelectedText = "Application engine Started\n";
                }
                else if (line.LastIndexOf("Drivers not found") > 0)
                {
                    richTextBox1.SelectedText = "Drivers were not found navigate to settings Menu to install them\n";
                }
            }
        }
