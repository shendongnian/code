    private void rtbEditor_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        if (e.Command == ApplicationCommands.Copy)
        {
            ExpandSelectionForCopy();
            mHandlingCutAction = false;
        }
        else if( e.Command == ApplicationCommands.Cut )
        {
            ExpandSelectionForCopy();
            mHandlingCutAction = true;
        }
    }
