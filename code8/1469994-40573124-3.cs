    public MainWindow()
    {
        InitializeComponent();
        AdvancedMessageBox.OnRes += MessageBox_OnRes;
        AdvancedMessageBox.TaskBasedShow(
            "My message",
            "My caption",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question);
    }
    /// <summary>
    ///     Is getting triggered after the user pressed a button.
    /// </summary>
    /// <param name="res">The pressed button.</param>
    private void MessageBox_OnRes(MessageBoxResult res)
    {
        // Implement you logic here
    }
