    void InsertIDsNamesAndAddWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        if (columns == 5)
        {
            //do your normal processing
            e.Result = true; // we're OK
        }
        else
        {
            //if requirements are not met then display error message
            System.Windows.MessageBox.Show("There must be five columns in this 
           file", MessageBoxButton.OK, MessageBoxImage.Error);
           
           e.Result = false; // something wrong
        }
    }
