    private ObservableCollection<PersonEntitiy> allStaff;
    private Thread dataFileTransactionsThread;
    
    #region Constructor
    public staffRepository() {
        allStaff = getStaffDataFromTextFile();
        dataFileTransactionsThread = new Thread(UpdateDataFileThread);
    }
    #endregion
    public void UpdateDataFile(ObservableCollection<PersonEntitiy> allStaff)     
    {
        dataFileTransactionsThread.Start(allStaff);
        // If you want to wait until the save finishes, uncomment the following line
        // dataFileTransactionsThread.Join();
    }
    
    private void UpdateDataFileThread(object data) {
        var allStaff = (ObservableCollection<PersonEntitiy>)data;
        System.Diagnostics.Debug.WriteLine("dataFileTransactions Thread Status："+ dataFileTransactionsThread.ThreadState);
    
        string containsWillBeSaved = "";
    
        // ...
    
        File.WriteAllText(fullPathToDataFile, containsWillBeSaved);
        System.Diagnostics.Debug.WriteLine("Data Save Successfull");
    
        System.Diagnostics.Debug.WriteLine("dataFileTransactions Thread Status：" + dataFileTransactionsThread.ThreadState);
    
    }
