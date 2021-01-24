    private void SetCurrentItemInEditMode(bool EditMode)
    {
        MyFiles obj = ListView1.SelectedItem as MyFiles;
        obj.IsInEditMode = EditMode;
    }
