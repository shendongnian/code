    private string fileOutputLocation { get; set; }
    private void lblSaveFile_Click(object sender, EventArgs e)
    {
        bool fileSelected = false;
        Try(() =>
        {
          SaveFileDialog save = new SaveFileDialog();
          save.Title = "Save File";
          save.Filter = "Text Files (*txt) | *.txt";
          if (save.ShowDialog() == DialogResult.OK)
          {
             fileOutputLocation = save.FileName;
             fileSelected = true;
          }
       });
       if (fileSelected)
       {
          bool fileSaved = SaveFile();
          MessageBox.Show("File saved successfully: " + fileSaved.ToString());
       }
    }
    private bool SaveFile()
    {
       TryDeleteFile();
       bool fileSaved = false;
       Try(()=>
       {
         File.WriteAllText(fileOutputLocation, txtTextBox.Text);
         fileSaved = true;
       });
       return fileSaved;
    }
    private void TryDeleteFile()
    {
       Try(()=>
       {
          if (File.Exists(fileOutputLocation)
          {
             File.Delete(fileOutputLocation)
          }
       });
    }
    private void Try(Action action)
    {
        try
        {
            action();
        }
        catch (Exception e)
        {
            MessageBox.Show(string.Format("The following exception was thrown:\r\n{0}\r\n\r\nFile path: {1}", e.ToString(), fileOutputLocation));
        }
    }
