    line = sr.ReadLine();
    //Continue to read until you reach end of file
    while (line != null)
    {
        this.listBox2.Items.Add(Path.GetFileName(line));
        selectedFiles.Add(line);
        //Read the next line
        line = sr.ReadLine();
    }
    //close the file
    sr.Close();
