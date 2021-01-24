    private void Load_File_Contents_BTN_Click(object sender, RoutedEventArgs e)
    {
          string FilePath = File_Path_TB.Text;
          string File_Contents = File.ReadAllText(FilePath);
          MessageBox.Show(File_Contents);
    }
