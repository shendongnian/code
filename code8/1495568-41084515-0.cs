    string[] textFiles = System.IO.Directory.GetFiles(path, "*.txt");
    foreach (string file in textFiles)
    {
        // Remove the directory from the string
        string filename = file.Substring(file.LastIndexOf(@"\") + 1);
        // Remove the extension from the filename
        string name = filename.Substring(0, filename.LastIndexOf(@"."));
        // Add the name to the combo box
        combobox1.Items.Add(name);
    }
