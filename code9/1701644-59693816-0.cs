    private void btnExport_Click(object sender, RoutedEventArgs e)
      {            
         string ExportName = (sender as System.Windows.Controls.Button).Name.ToString();
         bool result = Export.SaveToCSV(TrkDataGrid, ExportName);
         if (result == true)
         {
          MessageBoxResult result = System.Windows.MessageBox.Show("Exported successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
         }
      }
     public bool SaveToCSV(System.Windows.Controls.DataGrid dataGrid,string Filename)
      {
        bool IsVaild = false;
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Title = "Save CSV Files";
        saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
        saveFileDialog.FileName = Filename;           
        string gridname = Filename;
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
         string  path = System.IO.Path.GetFullPath(saveFileDialog.FileName);                    
         createcsvfile(dataGrid, path);              
          IsVaild = true;
        }
        return IsVaild;      
      }
     private void createcsvfile(System.Windows.Controls.DataGrid dataGrid, string FilePath)
      {            
        dataGrid.SelectAllCells();
        dataGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;           
        ApplicationCommands.Copy.Execute(null, dataGrid);
        dataGrid.UnselectAllCells();
        String result = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.CommaSeparatedValue);
        File.AppendAllText(FilePath, result, UnicodeEncoding.UTF8);         
      } 
