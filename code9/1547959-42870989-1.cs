       string[] subdirectories = Directory.GetDirectories(path);
        for (int i = 0; i < subdirectories.Length; i++)
        {
            MessageBox.Show(subdirectories[i]);
        }
       string[] subdirectories = Directory.GetDirectories(path);
        foreach (string directory in subdirectories)
        {
            MessageBox.Show(directory);
        }
