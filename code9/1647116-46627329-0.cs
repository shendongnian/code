    private void ReturnData_Click(object sender, RoutedEventArgs e)
    {
        var mainWindow = Application.Current.MainWindow;
        var val = RichEditControl1.Text;
    
        mainWindow.TbNoteText.Text = val;
        Close();
    }
