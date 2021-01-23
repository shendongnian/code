    private void chooseNewLabel()
    {
        if (ScriptCollection.Count > 0)
        {
            ScriptCollection = P4LabelBatteryModel.TagsFilesModel(NewLabel, ScriptCollection);
            ++FilesProcessedBlck;
        }
    }
