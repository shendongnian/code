    public static ObservableCollection<ScriptModel> TagsFilesModel(string NewLabel, IList<ScriptModel> scriptsToTagColl)
    {
        string newLabel = NewLabel;
        string[] files = null;
        //  This will generate an IPC when returned
        ObservableCollection<ScriptModel> newCollection = new ObservableCollection<ScriptModel>();
        //code here that modifies newCollection  xaml updates when this returns, _p4LabelBatteryViewModel.FilesProcessedBlck++; does not.
        return newCollection;
    }
