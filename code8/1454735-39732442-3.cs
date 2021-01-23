     private void shouldExtract()
        {
            if (MyProject.Properties.Settings.Default.DeleteExtractionFolder == true)
            {
                if (Directory.Exists(myExtractionDirectory))
                {
                    Directory.Delete(myExtractionDirectory);
                    //unzip
                    MyProject.Properties.Settings.Default.DeleteExtractionFolder = false;
                }
            }
        }
